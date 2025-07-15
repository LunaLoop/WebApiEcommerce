using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.Dtos;

namespace WebApiEcommerce.RN
{
    public class ZonaRN
    {
        private readonly TiendaVirtualContext _context;
        public ZonaRN(TiendaVirtualContext context)
        {
            _context = context;
        }
        public async Task<List<ZonaDto>> ObtenerZonaAsync()
        {
            return await _context.Zona
                .Select(p => new ZonaDto
                {
                    Id = p.Id,
                    NombreZona = p.NombreZona,
                    
                }).ToListAsync();
        }
    }
}
