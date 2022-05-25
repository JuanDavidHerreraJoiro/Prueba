using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        private EstadoService estadoService;
        public EstadosController(VueloDbContext context) {
            estadoService = new EstadoService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<EstadoViewModel>? Get() => estadoService.ConsultarTodos();

    }
}