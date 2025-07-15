using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class VistaProductosmasvendidosporanio
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int? Anio { get; set; }

    public double? CantidadTotalVendida { get; set; }

    public double? MontoTotalVendido { get; set; }
}
