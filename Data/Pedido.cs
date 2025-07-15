using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Pedido
{
    public int Id { get; set; }

    public DateTime FechaPedido { get; set; }

    public string? EstadoPedido { get; set; }

    public int? IdCliente { get; set; }

    public int? DireccionEnvioId { get; set; }

    public virtual ICollection<Credito> Credito { get; set; } = new List<Credito>();

    public virtual ICollection<Detallepedido> Detallepedido { get; set; } = new List<Detallepedido>();

    public virtual Direccionenvio? DireccionEnvio { get; set; }

    public virtual ICollection<Estadopedidohistorial> Estadopedidohistorial { get; set; } = new List<Estadopedidohistorial>();

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
