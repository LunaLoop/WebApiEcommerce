using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Lote
{
    public int Id { get; set; }

    public string NroLote { get; set; } = null!;

    public virtual ICollection<Loteproducto> Loteproducto { get; set; } = new List<Loteproducto>();
}
