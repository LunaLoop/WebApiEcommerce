using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class VwInformeventas
{
    public int PedidoId { get; set; }

    public DateOnly? FechaPedido { get; set; }

    public string? HoraPedido { get; set; }

    public string? EstadoPedido { get; set; }

    public string? NombreCliente { get; set; }

    public string TipoCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; }

    public string? TelefonoCliente { get; set; }

    public string? DireccionEnvio { get; set; }

    public string? CiudadEnvio { get; set; }

    public float? CantidadProducto { get; set; }

    public float? PrecioUnitarioPedido { get; set; }

    public string? NombreProducto { get; set; }

    public float? PrecioVenta { get; set; }

    public string? CategoriaProducto { get; set; }

    public float? MontoUltimoPago { get; set; }

    public DateTime? FechaUltimoPago { get; set; }

    public string? TipoUltimoPago { get; set; }

    public float? MontoFactura { get; set; }

    public DateTime? FechaFactura { get; set; }
}
