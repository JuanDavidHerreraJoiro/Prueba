using Microsoft.EntityFrameworkCore;
using vuelo.Data;
using vuelo.Models;

namespace vuelo.Logic
{
    public class AereolineaService
    {
        private readonly VueloDbContext _context;
        public AereolineaService(VueloDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AereolineaViewModel>? ConsultarTodos() => _context.Aereolineas?.ToList();

        public AereolineaViewModel? ConsultarRuta(int id) => _context.Aereolineas?.Where(r => r.Id == id).FirstOrDefault();

        public GuardarResponse<AereolineaViewModel> Guardar()
        {

            var aereolinea = new AereolineaViewModel();

            try
            {
                _context.Aereolineas?.Add(aereolinea);

                _context.SaveChanges();
            }
            catch (System.Exception)
            {
                return new GuardarResponse<AereolineaViewModel>("Error en la base de datos. ");
            }

            return new GuardarResponse<AereolineaViewModel>(aereolinea);
        }
    }
}