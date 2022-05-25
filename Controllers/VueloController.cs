using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VueloController : ControllerBase
    {
        private VueloService vueloService;
        public VueloController(VueloDbContext context) {
            vueloService = new VueloService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<VueloViewModel>? Get() => vueloService.ConsultarTodos();


        //[Authorize(Roles = "ADMIN")]
        [HttpPost]
        public ActionResult<VueloViewModel> Post(VueloInputModel vueloInput)
        {

            var vuelo = MapearVuelo(vueloInput);

            var respuesta = vueloService.Guardar(vuelo);

            if (respuesta.Error)
            {
                ModelState.AddModelError("Guardar vuelo", respuesta.Mensaje!);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status500InternalServerError,
                };

                return StatusCode(500, problemDetails);
            }

            return Ok(new VueloViewModel(vuelo));
        }

        [NonAction]
        public VueloViewModel MapearVuelo(VueloInputModel vueloInput)
        {

            var vuelo = new VueloViewModel()
            {
                NumeroVuelo = vueloInput.NumeroVuelo,
                CiudadOrigenId = vueloInput.CiudadOrigenId,
                CiudadDestinoId = vueloInput.CiudadDestinoId,
                Fecha = DateTime.Parse(vueloInput.Fecha!).ToString(),
            HoraSalida = vueloInput.HoraSalida!,
                HoraLlegada = vueloInput.HoraLlegada!,
                AereolineaId = vueloInput.AereolineaId,
                EstadoVueloId = vueloInput.EstadoVueloId
            };

            return vuelo;
        }
    }

}