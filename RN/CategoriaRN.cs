using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.Dtos;

namespace WebApiEcommerce.RN
{
    public class CategoriaRN
    {
        private readonly TiendaVirtualContext _context;
        public CategoriaRN(TiendaVirtualContext context)
        {
            _context = context;
        }
        public async Task<List<CategoriaDto>> ObtenerCategoriaAsync()
        {
            return await _context.Categoria
                .Select(p => new CategoriaDto
                {
                    Id = p.Id,
                    NombreCategoria = p.NombreCategoria,
                    Descripcion = p.Descripcion,

                }).ToListAsync();
        }
    }
}
