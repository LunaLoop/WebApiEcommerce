using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Pago
{
    public int Id { get; set; }

    public int IdPedido { get; set; }

    public DateTime FechaPago { get; set; }

    public float Monto { get; set; }

    public string TipoPago { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
