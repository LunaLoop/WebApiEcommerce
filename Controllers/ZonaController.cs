using Microsoft.AspNetCore.Mvc;
using WebApiEcommerce.Dtos;
using WebApiEcommerce.RN;

namespace WebApiEcommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZonaController : ControllerBase
    {
        private readonly ZonaRN _zonarn;

        public ZonaController(ZonaRN zonarn)
        {
            _zonarn = zonarn;
        }

        [HttpGet]
        public async Task<ActionResult<List<ZonaDto>>> Get()
        {
            var zona = await _zonarn.ObtenerZonaAsync();
            return Ok(zona);
        }
    }

   
}
