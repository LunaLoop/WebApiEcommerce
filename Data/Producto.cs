using System;
using System.Collections.Generic;

namespace WebApiEcommerce.Data;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public float PrecioVenta { get; set; }

    public int? IdCategoria { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<Almacenproducto> Almacenproducto { get; set; } = new List<Almacenproducto>();

    public virtual ICollection<Carritoproducto> Carritoproducto { get; set; } = new List<Carritoproducto>();

    public virtual ICollection<Detallepedido> Detallepedido { get; set; } = new List<Detallepedido>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Loteproducto> Loteproducto { get; set; } = new List<Loteproducto>();

    public virtual ICollection<Proveedorproducto> Proveedorproducto { get; set; } = new List<Proveedorproducto>();
}
