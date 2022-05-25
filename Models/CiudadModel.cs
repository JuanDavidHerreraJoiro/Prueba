using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vuelo.Models
{
    public class CiudadViewModel
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }
    }
}