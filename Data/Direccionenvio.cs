using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Direccionenvio
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Departamento { get; set; }

    public string? CodigoPostal { get; set; }

    public virtual ICollection<Pedido> Pedido { get; set; } = new List<Pedido>();

    public virtual Usuario? Usuario { get; set; }
}
