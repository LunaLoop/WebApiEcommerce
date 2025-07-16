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
        [HttpGet("{id}")]
        
        public async Task<ActionResult<ProductoVerDto>> ObtenerPorId(int id)
        {
            var producto = await _productoRN.ObtenerPorIdAsync(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromForm] ProductoCrearDto dto)
        {
            var actualizado = await _productoRN.ActualizarAsync(id, dto);
            if (!actualizado)
                return NotFound(new { mensaje = "Producto no encontrado" });

            return Ok(new { mensaje = "Producto actualizado correctamente" });
        }
        [HttpGet("categoria/{idCategoria}")]
        public async Task<IActionResult> ObtenerPorCategoria(int idCategoria)
        {
            var productos = await _productoRN.ListarPorCategoriaAsync(idCategoria);

            if (productos == null || productos.Count == 0)
                return NotFound(new { mensaje = "No se encontraron productos para esta categoría." });

            return Ok(productos);
        }
        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNombre([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return BadRequest(new { mensaje = "Debe proporcionar un nombre para buscar." });

            var productos = await _productoRN.BuscarPorNombreAsync(nombre);

            if (productos == null || productos.Count == 0)
                return NotFound(new { mensaje = "No se encontraron productos con ese nombre." });

            return Ok(productos);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var eliminado = await _productoRN.EliminarAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Producto no encontrado" });

            return Ok(new { mensaje = "Producto eliminado correctamente" });
        }



    }
}
