using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Proveedor
{
    public int Id { get; set; }

    public string NombreProveedor { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Proveedorproducto> Proveedorproducto { get; set; } = new List<Proveedorproducto>();
}
