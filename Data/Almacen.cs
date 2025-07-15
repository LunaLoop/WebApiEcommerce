using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Almacen
{
    public int Id { get; set; }

    public string? NombreAlmacen { get; set; }

    public string? Direccion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Almacenproducto> Almacenproducto { get; set; } = new List<Almacenproducto>();
}
