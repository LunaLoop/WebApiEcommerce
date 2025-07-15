using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Topproductosmasvendidos
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public float PrecioUnitarioBase { get; set; }

    public double? CantidadVendida { get; set; }

    public double? MontoTotal { get; set; }
}
