using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vuelo.Models
{
    public class PersonaModel
    {
        [Required(ErrorMessage = "La identificación es requerida")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string? Apellidos { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]    
        public string? Correo { get; set; }

    }

    public class PersonaInputModel : PersonaModel
    {
        public UsuarioInputModel? Usuario { get; set; }
    }

    public class PersonaViewModel : PersonaModel
    {
        public PersonaViewModel() {}
        public PersonaViewModel(PersonaViewModel Persona, string rol,string contrasena, string nombreUsuario) {
            Identificacion = Persona.Identificacion;
            Nombres = Persona.Nombres!.ToUpper();
            Apellidos = Persona.Apellidos!.ToUpper();
            Correo = Persona.Correo;
            Usuario = new UsuarioViewModel(rol, contrasena, nombreUsuario);
        }

        [Key]
        public int Id { get; set; }
        public UsuarioViewModel? Usuario { get; set; }

        [ForeignKey("UsuarioViewModel")]
        public int UsuarioId { get; set; }
        
    }
}