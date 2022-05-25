using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private PersonaService personaService;
        public PersonaController(VueloDbContext context) {
            personaService = new PersonaService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<PersonaViewModel>? Get() => personaService.ConsultarTodos();


        //[Authorize(Roles = "ADMIN")]
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel Input, string rol, string contrasena, string nombreUsuario)
        {

            var persona = MapearVuelo(Input,rol, contrasena, nombreUsuario);

            var respuesta = personaService.Guardar(persona, rol, contrasena, nombreUsuario);

            if (respuesta.Error)
            {
                ModelState.AddModelError("Guardar", respuesta.Mensaje!);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status500InternalServerError,
                };

                return StatusCode(500, problemDetails);
            }

            return Ok(new PersonaViewModel(persona, rol, contrasena, nombreUsuario));
        }

        [NonAction]
        public PersonaViewModel MapearVuelo(PersonaInputModel Input, string rol, string contrasena, string nombreUsuario)
        {

            var vuelo = new PersonaViewModel()
            {
                Identificacion = Input.Identificacion,
                Nombres = Input.Nombres,
                Apellidos = Input.Apellidos,
                Correo = Input.Correo,
                Usuario= new UsuarioViewModel(rol, contrasena, nombreUsuario),
                
            };

            return vuelo;
        }
    }
}