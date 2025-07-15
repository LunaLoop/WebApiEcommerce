using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<Carrito> Carrito { get; set; } = new List<Carrito>();

    public virtual ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();

    public virtual ICollection<Direccionenvio> Direccionenvio { get; set; } = new List<Direccionenvio>();

    public virtual ICollection<Notificacionusuario> Notificacionusuario { get; set; } = new List<Notificacionusuario>();
}
