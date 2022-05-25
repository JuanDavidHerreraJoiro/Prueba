using System.ComponentModel.DataAnnotations;

namespace vuelo.Models
{
    public class AereolineaViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }
    }
}