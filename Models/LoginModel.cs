using System.ComponentModel.DataAnnotations;

namespace vuelo.Models
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "El usuario o el correo es requerido")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string? Contrasena { get; set; }
    }
    public class LoginViewModel : LoginInputModel
    {
        public string? Rol { get; set; }
        public string? Token { get; set; }
    }
}