using BC = BCrypt.Net.BCrypt;
using System.ComponentModel.DataAnnotations;

namespace vuelo.Models
{
    public class UsuarioInputModel
    {
        
    }

    public class UsuarioViewModel : UsuarioInputModel
    {
        public UsuarioViewModel() {
            Usuario = "";
        }
        public UsuarioViewModel(string rol, string? contrasena, string usuario) {
            Contrasena = BC.HashPassword(contrasena);
            Rol = rol;
            Usuario = usuario;
        }

        [Key]
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Contrasena { get; set; }
        public string? Rol { get; set; }

    }
}
