using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.Dtos;

namespace WebApiEcommerce.RN
{
    public class DireccionEnvioRN
    {
        private readonly TiendaVirtualContext _context;
        public DireccionEnvioRN(TiendaVirtualContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Direccionenvio>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            return await _context.Direccionenvio
                .Where(d => d.UsuarioId == usuarioId)
                .ToListAsync();
        }
        public async Task<bool> AgregarDireccionAsync(DireccionEnvioDto dto)
        {
            var direccion = new Direccionenvio
            {
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                Departamento = dto.Departamento,
                
                UsuarioId = dto.UsuarioId,
                Latitud = (decimal)dto.Latitud,
                Longitud = (decimal)dto.Longitud
            };

            _context.Direccionenvio.Add(direccion);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EditarDireccionAsync(int id, DireccionEnvioDto dto)
        {
            var direccion = await _context.Direccionenvio.FindAsync(id);
            if (direccion == null) return false;

            direccion.Direccion = dto.Direccion;
            direccion.Ciudad = dto.Ciudad;
            direccion.Departamento = dto.Departamento;
            direccion.Latitud = (decimal)dto.Latitud;
            direccion.Longitud = (decimal)dto.Longitud;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> EliminarDireccionAsync(int id)
        {
            var direccion = await _context.Direccionenvio.FindAsync(id);
            if (direccion == null) return false;

            _context.Direccionenvio.Remove(direccion);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
