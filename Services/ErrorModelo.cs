using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace vuelo.Services
{
    public class ErrorModelo
    {
        public static string NombreError = "ErrorServer";
        
        public static ValidationProblemDetails AgregarError(ModelStateDictionary ModelState, string mensaje) {
            
            ModelState.AddModelError(NombreError, mensaje);
            var problemDetails = new ValidationProblemDetails(ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };

            return problemDetails;
        }
    }
}