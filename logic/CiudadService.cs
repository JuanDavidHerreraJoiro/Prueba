using Microsoft.EntityFrameworkCore;
using vuelo.Data;
using vuelo.Models;

namespace vuelo.Logic
{
    public class CiudadService
    {
        private readonly VueloDbContext _context;
        public CiudadService(VueloDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CiudadViewModel>? ConsultarTodos() => _context.Ciudades?.ToList();

        public CiudadViewModel? ConsultarRuta(int id) => _context.Ciudades?.Where(r => r.Id == id).FirstOrDefault();

        public GuardarResponse<CiudadViewModel> Guardar()
        {

            var ciudad = new CiudadViewModel();

            try
            {
                _context.Ciudades?.Add(ciudad);

                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return new GuardarResponse<CiudadViewModel>("Error en la base de datos. ");
            }

            return new GuardarResponse<CiudadViewModel>(ciudad);
        }
    }
}