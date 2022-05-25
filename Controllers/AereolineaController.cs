using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AereolineaController : ControllerBase
    {
        private AereolineaService aereolineService;
        public AereolineaController(VueloDbContext context) {
            aereolineService = new AereolineaService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<AereolineaViewModel>? Get() => aereolineService.ConsultarTodos();

    }
}