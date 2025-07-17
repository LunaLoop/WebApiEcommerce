using Microsoft.EntityFrameworkCore;
using WebApiEcommerce.Data;
using WebApiEcommerce.Dtos;

namespace WebApiEcommerce.RN
{
    public class LoginRN
    {
        private readonly TiendaVirtualContext _context;
        public LoginRN(TiendaVirtualContext context)
        {
            _context = context;
        }
        public async Task<Usuario> AutenticarAsync(string correo, string contrasena)
        {
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Correo == correo);

            if (usuario == null)
                return null;

          
            if (usuario.Contrasena != contrasena)
                return null;

            return usuario;
        }
        public async Task<bool> RegistrarClienteAsync(UsuarioRegistroDto dto)
        {
            using var transaccion = await _context.Database.BeginTransactionAsync();

            try
            {
                var usuario = new Usuario
                {
                    NombreUsuario = dto.NombreUsuario,
                    Correo = dto.Correo,
                    Contrasena = dto.Contrasena, 
                    TipoUsuario = "Cliente"
                };

                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();

                var cliente = new Cliente
                {
                    Id = usuario.Id, // Mismo ID del usuario
                    Direccion = dto.Direccion,
                    Telefono = dto.Telefono,
                    BarrioId = dto.BarrioId,
                    Edad = dto.Edad,
                    Genero = dto.Genero,
                    UsuarioId = usuario.Id
                };

                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                if (dto.TipoCliente.ToLower() == "natural")
                {
                    var natural = new Clientenatural
                    {
                        Id = cliente.Id,
                        NombreCompleto = dto.NombreCompleto,
                        ApellidoPaterno = dto.ApellidoPaterno,
                        ApellidoMaterno = dto.ApellidoMaterno,
                        ClienteId = cliente.Id
                    };
                    _context.Clientenatural.Add(natural);
                }
                else if (dto.TipoCliente?.ToLower() == "juridico")
                {
                    var juridico = new Juridico
                    {
                        Id = GenerarIdJuridico(),
                        RazonSocial = dto.RazonSocial,
                        RepresentanteLegal = dto.RepresentanteLegal,
                        ClienteId = cliente.Id
                    };
                    _context.Juridico.Add(juridico);
                }
                else
                {
                    return false;
                }

                await _context.SaveChangesAsync();
                await transaccion.CommitAsync();

                return true;
            }
            catch
            {
                await transaccion.RollbackAsync();
                return false;
            }
        }
        private string GenerarIdJuridico()
        {
            var ultimoId = _context.Juridico
                .OrderByDescending(j => j.Id)
                .Select(j => j.Id)
                .FirstOrDefault();

            int numero = 1000;

            if (!string.IsNullOrEmpty(ultimoId) && ultimoId.StartsWith("J-"))
            {
                var partes = ultimoId.Split('-');
                if (partes.Length == 2 && int.TryParse(partes[1], out int num))
                {
                    numero = num;
                }
            }

            return $"J-{numero + 1}";
        }



    }
}
