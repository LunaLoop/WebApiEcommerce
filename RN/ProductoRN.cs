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
                Imagen = imagenUrl
            };

            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ProductoVerDto> ObtenerPorIdAsync(int id)
        {
            var producto = await _context.Producto
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
                return null;

            return new ProductoVerDto
            {
                Id = producto.Id,
                NombreProducto = producto.NombreProducto,
                PrecioVenta = producto.PrecioVenta,
                IdCategoria = (int)producto.IdCategoria,
                Imagen = producto.Imagen
            };
        }
        public async Task<bool> ActualizarAsync(int id, ProductoCrearDto dto)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
                return false;

           
            producto.NombreProducto = dto.NombreProducto;
            producto.PrecioVenta = dto.PrecioVenta ?? producto.PrecioVenta;
            producto.IdCategoria = dto.IdCategoria;

            // Solo si el usuario envía una imagen nueva
            if (dto.Imagen != null && dto.Imagen.Length > 0)
            {
                var nuevaImagenUrl = await _imagenService.SubirImagenAsync(dto.Imagen);
                producto.Imagen = nuevaImagenUrl;
            }

            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ProductoVerDto>> ListarPorCategoriaAsync(int idCategoria)
        {
            var productos = await _context.Producto
                .Where(p => p.IdCategoria == idCategoria)
                .Select(p => new ProductoVerDto
                {
                    Id = p.Id,
                    NombreProducto = p.NombreProducto,
                    PrecioVenta = p.PrecioVenta,
                    IdCategoria = (int)p.IdCategoria,
                    Imagen = p.Imagen
                })
                .ToListAsync();

            return productos;
        }
        public async Task<List<ProductoVerDto>> BuscarPorNombreAsync(string nombre)
        {
            var productos = await _context.Producto
                .Where(p => p.NombreProducto.Contains(nombre))
                .Select(p => new ProductoVerDto
                {
                    Id = p.Id,
                    NombreProducto = p.NombreProducto,
                    PrecioVenta = p.PrecioVenta,
                    IdCategoria = (int)p.IdCategoria,
                    Imagen = p.Imagen
                })
                .ToListAsync();

            return productos;
        }
        public async Task<bool> EliminarAsync(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
                return false;

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }






    }
}
