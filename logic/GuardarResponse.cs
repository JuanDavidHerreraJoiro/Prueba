
namespace vuelo.Logic
{
    public class GuardarResponse<T>
    {
        public GuardarResponse(T objeto)
        {
            Error = false;
            Objeto = objeto;
        }
        public GuardarResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public T? Objeto { get; set; }
    }
}