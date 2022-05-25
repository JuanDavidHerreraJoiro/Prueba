using Microsoft.EntityFrameworkCore;
using vuelo.Data;
using vuelo.Models;
using vuelo.Services;

namespace vuelo.Logic
{
    public class VueloService
    {
        private readonly VueloDbContext _context;
        private UsuarioService usuarioService;
        public VueloService(VueloDbContext context)
        {
            _context = context;
            usuarioService = new UsuarioService(context);
        }

        public IEnumerable<VueloViewModel>? ConsultarTodos() => _context.Vuelos?
            .Include("Aereolinea")
            .Include("EstadoVuelo")
            .Include("CiudadOrigen")
            .Include("CiudadDestino")
            .ToList();

        public VueloViewModel? ConsultarVuelo(int? NumeroVuelo) => _context.Vuelos?
            .Where(v => v.NumeroVuelo == NumeroVuelo)
            .Include("Aereolinea")
            .Include("EstadoVuelo")
            .Include("CiudadOrigen")
            .Include("CiudadDestino")
            .FirstOrDefault();


        public GuardarResponse<VueloViewModel> Guardar(VueloViewModel vuelo)
        {
            try
            {
                var vueloBuscado = ConsultarVuelo(vuelo.NumeroVuelo);

                if (vueloBuscado != null)
                {
                    return new GuardarResponse<VueloViewModel>($"El vuelo {vuelo.NumeroVuelo} ya se encuentra registrado");
                }

                if (vuelo.CiudadOrigenId == vuelo.CiudadDestinoId)
                {
                    return new GuardarResponse<VueloViewModel>("La ciudades de origen y destino no pueden ser las mismas. ");
                }

                //string nombreUsuario = "";

                var usuarios = usuarioService.ConsultarTodos();

                //nombreUsuario = Credenciales.CrearNombreUsuario(usuarios?.ToList(), vigilante.Nombres, vigilante.Apellidos);

                var vueloViewModel = new VueloViewModel(vuelo);

                _context.Vuelos?.Add(vueloViewModel);

                _context.SaveChanges();

                return new GuardarResponse<VueloViewModel>(vueloViewModel);

            }
            catch (System.Exception)
            {
                return new GuardarResponse<VueloViewModel>("Error en la base de datos. ");

            }
        }

    }
}