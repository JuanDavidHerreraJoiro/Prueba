using Microsoft.EntityFrameworkCore;
using vuelo.Data;
using vuelo.Models;

namespace vuelo.Logic
{
    public class EstadoService
    {
        private readonly VueloDbContext _context;
        public EstadoService(VueloDbContext context)
        {
            _context = context;
        }

        public IEnumerable<EstadoViewModel>? ConsultarTodos() => _context.Estados?.ToList();

        public EstadoViewModel? ConsultarRuta(int id) => _context.Estados?.Where(r => r.Id == id).FirstOrDefault();

        public GuardarResponse<EstadoViewModel> Guardar()
        {

            var estado = new EstadoViewModel();

            try
            {
                _context.Estados?.Add(estado);

                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return new GuardarResponse<EstadoViewModel>("Error en la base de datos. ");
            }

            return new GuardarResponse<EstadoViewModel>(estado);
        }
    }
}