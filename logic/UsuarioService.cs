using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vuelo.Data;
using vuelo.Models;

namespace vuelo.Logic
{
    public class UsuarioService
    {
        private readonly VueloDbContext _context;
        public UsuarioService(VueloDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioViewModel>? ConsultarTodos() => _context.Usuarios?.ToList();

        public UsuarioViewModel? ConsultarUsuarioXUsuario(string usuario) => _context.Usuarios?.FirstOrDefault(u => u.Usuario == usuario);

        public UsuarioViewModel? ValidarCredenciales(LoginInputModel model) => _context.Usuarios?.SingleOrDefault(u =>(u.Usuario == model.Usuario));
    }
}