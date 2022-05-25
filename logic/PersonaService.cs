using Microsoft.EntityFrameworkCore;
using vuelo.Data;
using vuelo.Models;
using vuelo.Services;

namespace vuelo.Logic
{
    public class PersonaService
    {
        private readonly VueloDbContext _context;
        private UsuarioService usuarioService;
        public PersonaService(VueloDbContext context)
        {
            _context = context;
            usuarioService = new UsuarioService(context);
        }

        public IEnumerable<PersonaViewModel>? ConsultarTodos() => _context.Personas?.Include(v => v.Usuario);


        public PersonaViewModel? ConsultarVigilanteXId(string? id) => _context.Personas?.Where(v => v.Identificacion == id).FirstOrDefault();

        public GuardarResponse<PersonaViewModel> Guardar(PersonaViewModel persona, string rol, string contrasena, string nombreUsuario)
        {
            try
            {
                var personaBuscado = ConsultarVigilanteXId(persona.Identificacion);

                if (personaBuscado != null)
                {
                    return new GuardarResponse<PersonaViewModel>($"La persona {persona.Identificacion} ya se encuentra registrado");
                }

                //string nombreUsuario = "";

                var usuarios = usuarioService.ConsultarTodos();

                //nombreUsuario = Credenciales.CrearNombreUsuario(usuarios?.ToList(), vigilante.Nombres, vigilante.Apellidos);

                var personaViewModel = new PersonaViewModel(persona, rol, contrasena, nombreUsuario);
                var usuarioViewModel = new UsuarioViewModel(rol, contrasena, nombreUsuario);

                _context.Personas?.Add(personaViewModel);
                //_context.Usuarios?.Add(usuarioViewModel);

                _context.SaveChanges();

                return new GuardarResponse<PersonaViewModel>(personaViewModel);

            }
            catch (System.Exception)
            {
                return new GuardarResponse<PersonaViewModel>("Error en la base de datos. ");

            }
        }
    }
}