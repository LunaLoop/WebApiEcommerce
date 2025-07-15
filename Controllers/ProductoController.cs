using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.RN;

namespace WebApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
       private readonly ProductoRN _productoRN;
       public ProductoController (ProductoRN productoRN)
        {
            _productoRN = productoRN;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductoVerDto>>> Get()
        {
            var producto = await _productoRN.ObtenerProductoAsync();
            return Ok(producto);
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AgregarProducto([FromForm] ProductoCrearDto productoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _productoRN.AgregarProductoAsync(productoDto);
            if (resultado)
                return Ok("Producto agregado correctamente");

            return StatusCode(500, "Ocurrió un error al guardar");
        }
    }
}
