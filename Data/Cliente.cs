using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? BarrioId { get; set; }

    public int? Edad { get; set; }

    public string? Genero { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Barrio? Barrio { get; set; }

    public virtual ICollection<Clientenatural> Clientenatural { get; set; } = new List<Clientenatural>();

    public virtual ICollection<Juridico> Juridico { get; set; } = new List<Juridico>();

    public virtual ICollection<Pedido> Pedido { get; set; } = new List<Pedido>();

    public virtual Usuario? Usuario { get; set; }
}
