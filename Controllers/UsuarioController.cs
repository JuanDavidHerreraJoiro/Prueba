using Microsoft.AspNetCore.Mvc;
using vuelo.Data;
using vuelo.Logic;
using vuelo.Models;

namespace vuelo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService usuarioService;
        public UsuarioController(VueloDbContext context) {
            usuarioService = new UsuarioService(context);
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IEnumerable<UsuarioViewModel>? Get() => usuarioService.ConsultarTodos();

        // GET api/<UsuarioController>/5
        [HttpGet("{usuario}")]
        public UsuarioViewModel? Get(string usuario) => usuarioService.ConsultarUsuarioXUsuario(usuario);
    }
}