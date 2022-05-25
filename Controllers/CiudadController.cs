using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadedController : ControllerBase
    {
        private CiudadService ciudadService;
        public CiudadedController(VueloDbContext context) {
            ciudadService = new CiudadService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<CiudadViewModel>? Get() => ciudadService.ConsultarTodos();

    }
}