using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Detallepedido
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public float Cantidad { get; set; }

    public float Precio { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
