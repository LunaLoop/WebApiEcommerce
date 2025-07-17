using System.ComponentModel.DataAnnotations;

namespace WebApiEcommerce.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
    public class UsuarioRegistroDto
    {
        [Required]
        public string NombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Contrasena { get; set; }

        // Cliente
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int BarrioId { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }

        // Tipo de cliente: "natural" o "juridico"
        [Required]
        public string TipoCliente { get; set; }

        // Natural
        public string NombreCompleto { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        // Juridico
        public string RazonSocial { get; set; }
        public string RepresentanteLegal { get; set; }
    }

}
