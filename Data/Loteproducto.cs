using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Loteproducto
{
    public int IdLote { get; set; }

    public int IdProducto { get; set; }

    public float Stock { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public virtual Lote IdLoteNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
