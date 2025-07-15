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
    }
}
