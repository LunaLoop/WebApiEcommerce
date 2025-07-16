using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.RN;

namespace WebApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaRN _categoriarn;
        public CategoriaController(CategoriaRN categoriarn)
        {
            _categoriarn = categoriarn;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoriaDto>>> Get()
        {
            var cat3egoria = await _categoriarn.ObtenerCategoriaAsync();
            return Ok(cat3egoria);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> ObtenerPorId(int id)
        {
            var categoria = await _categoriarn.ObtenerCategoriaPorIdAsync(id);
            if (categoria == null) { return NotFound(); }
            return Ok(categoria);

        }
        [HttpPost]
        public async Task<IActionResult> AgregarCategoria([FromBody] CategoriaCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _categoriarn.AgregarCategoriaAsync(dto);
            if (resultado)
                return Ok(new { mensaje = "Categoría agregada correctamente" });

            return StatusCode(500, new { mensaje = "Ocurrió un error al guardar" });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] CategoriaCrearDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizada = await _categoriarn.ActualizarCategoriaAsync(id, dto);
            if (!actualizada)
                return NotFound(new { mensaje = "Categoría no encontrada" });

            return Ok(new { mensaje = "Categoría actualizada correctamente" });
        }

    }
}
