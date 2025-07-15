using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Zona
{
    public int Id { get; set; }

    public string NombreZona { get; set; } = null!;

    public virtual ICollection<Barrio> Barrio { get; set; } = new List<Barrio>();
}
