using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.RN;

namespace WebApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginRN _loginRN;
        public LoginController(LoginRN loginRN)
        {
            _loginRN = loginRN;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _loginRN.AutenticarAsync(dto.Correo, dto.Contrasena);

            if (usuario == null)
                return Unauthorized(new { mensaje = "Correo o contraseña incorrectos" });

            return Ok(new
            {
                id = usuario.Id,
                nombreUsuario = usuario.NombreUsuario,
                correo = usuario.Correo,
                tipoUsuario = usuario.TipoUsuario
            });
        }
        [HttpPost("registro")]
        public async Task<IActionResult> RegistrarCliente([FromBody] UsuarioRegistroDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _loginRN.RegistrarClienteAsync(dto);

            if (!resultado)
                return BadRequest(new { mensaje = "Error al registrar usuario o tipo de cliente inválido." });

            return Ok(new { mensaje = "Cliente registrado correctamente" });
        }


    }
}
