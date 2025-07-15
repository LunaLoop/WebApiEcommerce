using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Cuota
{
    public int Id { get; set; }

    public float Monto { get; set; }

    public float Interes { get; set; }

    public DateTime FechaPagoProgramado { get; set; }

    public DateTime? FechaPago { get; set; }

    public int? IdCredito { get; set; }

    public virtual Credito? IdCreditoNavigation { get; set; }
}
