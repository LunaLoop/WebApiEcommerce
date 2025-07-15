using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Almacenproducto
{
    public int IdAlmacen { get; set; }

    public int IdProducto { get; set; }

    public float? Cantidad { get; set; }

    public string? Unidad { get; set; }

    public virtual Almacen IdAlmacenNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
