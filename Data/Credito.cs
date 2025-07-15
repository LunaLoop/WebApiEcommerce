using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Credito
{
    public int Id { get; set; }

    public float Monto { get; set; }

    public float InteresMensual { get; set; }

    public DateTime FechaDesembolso { get; set; }

    public int? IdPedido { get; set; }

    public virtual ICollection<Cuota> Cuota { get; set; } = new List<Cuota>();

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
