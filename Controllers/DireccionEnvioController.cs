using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.RN;

namespace WebApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DireccionEnvioController : ControllerBase
    {
        private readonly DireccionEnvioRN _direccionEnvioRN;
        public DireccionEnvioController(DireccionEnvioRN direccionEnvioRN)
        {
            _direccionEnvioRN = direccionEnvioRN;
        }
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetDirecciones(int usuarioId)
        {
            var direcciones = await _direccionEnvioRN.ObtenerPorUsuarioAsync(usuarioId);
            return Ok(direcciones);
        }
        [HttpPost]
        public async Task<IActionResult> AgregarDireccion([FromBody] DireccionEnvioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _direccionEnvioRN.AgregarDireccionAsync(dto);

            if (resultado)
                return Ok("Dirección registrada correctamente");

            return StatusCode(500, "Error al registrar dirección");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarDireccion(int id, [FromBody] DireccionEnvioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = await _direccionEnvioRN.EditarDireccionAsync(id, dto);
            return resultado ? Ok("Dirección actualizada correctamente") : NotFound("Dirección no encontrada");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDireccion(int id)
        {
            var resultado = await _direccionEnvioRN.EliminarDireccionAsync(id);
            return resultado ? Ok("Dirección eliminada correctamente") : NotFound("Dirección no encontrada");
        }

    }
}
