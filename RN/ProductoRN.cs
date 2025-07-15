using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.Services;

namespace WebApiEcommerce.RN
{
    public class ProductoRN
    {
        private readonly TiendaVirtualContext _context;
        private readonly ImagenService _imagenService;
        public ProductoRN(TiendaVirtualContext context, ImagenService imagenService)
        {
            _context = context;
            _imagenService = imagenService;
        }
        public async Task<List<ProductoVerDto>> ObtenerProductoAsync()
        {
            return await _context.Producto
                .Select(p => new ProductoVerDto
                {
                    Id = p.Id,
                    NombreProducto = p.NombreProducto,
                    PrecioVenta = p.PrecioVenta,
                    IdCategoria = (int)p.IdCategoria,
                    Imagen = p.Imagen ?? ""  


                }).ToListAsync();
        }
        public async Task<bool> AgregarProductoAsync(ProductoCrearDto dto)
        {
            var imagenUrl = await _imagenService.SubirImagenAsync(dto.Imagen);

            var producto = new Producto
            {
                NombreProducto = dto.NombreProducto,
                PrecioVenta = dto.PrecioVenta ?? 0,
                IdCategoria = dto.IdCategoria,
                Imagen = imagenUrl// Asegúrate que tu modelo tenga este campo
            };

            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
