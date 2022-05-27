using System.ComponentModel.DataAnnotations;

namespace vuelo.Models
{
    public class VueloInputModel
    {
        [Required(ErrorMessage = "El numero de vuelo es requerido")]
        public int? NumeroVuelo { get; set; }
        [Required(ErrorMessage = "La ciudad de origen es requerida")]
        public int? CiudadOrigenId { get; set; }

        [Required(ErrorMessage = "La ciudad de destino es requerida")]
        public int? CiudadDestinoId { get; set; }

        [Required(ErrorMessage = "La fecha de salida es requerida")]
        [ValidarFecha( ErrorMessage="La fecha debe ser mayor a la hoy")]
        public DateTime? Fecha { get; set; }

        [Required(ErrorMessage = "La hora de salida es requerida")]
        [RegularExpression(@"([01]?[0-9]|2[0-3]):[0-5][0-9]$", 
            ErrorMessage = "El formato debe ser de sistema horario de 24 horas hh:mm")]
        public string? HoraSalida { get; set; }

        [Required(ErrorMessage = "La hora de llegada es requerida")]
        [RegularExpression(@"([01]?[0-9]|2[0-3]):[0-5][0-9]$", 
            ErrorMessage = "El formato debe ser de sistema horario de 24 horas hh:mm")]
        public string? HoraLlegada { get; set; }

        [Required(ErrorMessage = "La aerolinea es requerida")]
        public int? AereolineaId { get; set; }

        [Required(ErrorMessage = "El estado del vuelo es requerido")]
        public int? EstadoVueloId { get; set; }
    }

    public class VueloViewModel : VueloInputModel
    {
        public VueloViewModel()
        {

        }

        public VueloViewModel(VueloInputModel vuelo)
        {
            this.NumeroVuelo = vuelo.NumeroVuelo;
            this.CiudadOrigenId = vuelo.CiudadOrigenId;
            this.CiudadDestinoId = vuelo.CiudadDestinoId;
            this.Fecha = vuelo.Fecha;
            this.HoraSalida = vuelo.HoraSalida;
            this.HoraLlegada = vuelo.HoraLlegada;
            this.AereolineaId = vuelo.AereolineaId;
            this.EstadoVueloId = vuelo.EstadoVueloId;
        }
        [Key]
        public int Id { get; set; }
        public CiudadViewModel? CiudadOrigen { get; set; }
        public CiudadViewModel? CiudadDestino { get; set; }
        public AereolineaViewModel? Aereolinea { get; set; }
        public EstadoViewModel? EstadoVuelo { get; set; }
    }

    public class ValidarFecha : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (DateTime.Parse(value?.ToString()!) >= DateTime.Now.Date)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}