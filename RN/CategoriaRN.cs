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
        public async Task<CategoriaDto> ObtenerCategoriaPorIdAsync(int id)
        {
            var categoria = await _context.Categoria
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null) {
                return null;
            }
            return new CategoriaDto
            {
                Id = categoria.Id,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
            };
        }
        public async Task<bool> AgregarCategoriaAsync(CategoriaCrearDto dto)
        {
            var categoria = new Categoria
            {
                NombreCategoria = dto.NombreCategoria,
                Descripcion = dto.Descripcion
            };

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ActualizarCategoriaAsync(int id, CategoriaCrearDto dto)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
                return false;

            categoria.NombreCategoria = dto.NombreCategoria;
            categoria.Descripcion = dto.Descripcion;

            _context.Categoria.Update(categoria);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
