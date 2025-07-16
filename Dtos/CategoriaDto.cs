using System.ComponentModel.DataAnnotations;

namespace WebApiEcommerce.Dtos
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string NombreCategoria { get; set; }
        public  string Descripcion {  get; set; }
    }
    public class CategoriaCrearDto
    {
        [Required]
        public string NombreCategoria { get; set; }
       
       
        public string Descripcion { get; set; }
    }
}
