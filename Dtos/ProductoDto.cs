using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiEcommerce.Dtos
{
    public class ProductoCrearDto
    {
        
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public float? PrecioVenta { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría válida.")]
        public int IdCategoria { get; set; }

        public IFormFile Imagen { get; set; }
       
    }
    public class ProductoVerDto
    {
        public int Id { get; set; }
        [Required]
        public string NombreProducto { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public float? PrecioVenta { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría válida.")]
        public int IdCategoria { get; set; }

        public string Imagen { get; set; }

    }

}
