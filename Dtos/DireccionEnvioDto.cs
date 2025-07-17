using System.ComponentModel.DataAnnotations;

namespace WebApiEcommerce.Dtos
{
    public class DireccionEnvioDto
    {
        public string Direccion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        public string Departamento { get; set; }


        
        public int UsuarioId { get; set; }

        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
    
}
