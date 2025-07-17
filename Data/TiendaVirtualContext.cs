using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebApiEcommerce.Data;

public partial class TiendaVirtualContext : DbContext
{
    public TiendaVirtualContext()
    {
    }

    public TiendaVirtualContext(DbContextOptions<TiendaVirtualContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacen> Almacen { get; set; }

    public virtual DbSet<Almacenproducto> Almacenproducto { get; set; }

    public virtual DbSet<Barrio> Barrio { get; set; }

    public virtual DbSet<Carrito> Carrito { get; set; }

    public virtual DbSet<Carritoproducto> Carritoproducto { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Clientenatural> Clientenatural { get; set; }

    public virtual DbSet<Credito> Credito { get; set; }

    public virtual DbSet<Cuota> Cuota { get; set; }

    public virtual DbSet<Detallepedido> Detallepedido { get; set; }

    public virtual DbSet<Direccionenvio> Direccionenvio { get; set; }

    public virtual DbSet<Estadopedidohistorial> Estadopedidohistorial { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Juridico> Juridico { get; set; }

    public virtual DbSet<Lote> Lote { get; set; }

    public virtual DbSet<Loteproducto> Loteproducto { get; set; }

    public virtual DbSet<Notificacionusuario> Notificacionusuario { get; set; }

    public virtual DbSet<Pago> Pago { get; set; }

    public virtual DbSet<Pedido> Pedido { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Proveedorproducto> Proveedorproducto { get; set; }

    public virtual DbSet<Topproductosmasvendidos> Topproductosmasvendidos { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<VistaProductosmasvendidosporanio> VistaProductosmasvendidosporanio { get; set; }

    public virtual DbSet<VwInformeventas> VwInformeventas { get; set; }

    public virtual DbSet<Zona> Zona { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;pwd=123456789;database=TiendaVirtual", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.41-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Almacen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("almacen");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(90);
            entity.Property(e => e.Direccion).HasMaxLength(90);
            entity.Property(e => e.NombreAlmacen).HasMaxLength(90);
        });

        modelBuilder.Entity<Almacenproducto>(entity =>
        {
            entity.HasKey(e => new { e.IdAlmacen, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("almacenproducto");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.Unidad).HasMaxLength(20);

            entity.HasOne(d => d.IdAlmacenNavigation).WithMany(p => p.Almacenproducto)
                .HasForeignKey(d => d.IdAlmacen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("almacenproducto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Almacenproducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("almacenproducto_ibfk_2");
        });

        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("barrio");

            entity.HasIndex(e => e.ZonaId, "ZonaId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreBarrio).HasMaxLength(50);

            entity.HasOne(d => d.Zona).WithMany(p => p.Barrio)
                .HasForeignKey(d => d.ZonaId)
                .HasConstraintName("barrio_ibfk_1");
        });

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("carrito");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Carrito)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("carrito_ibfk_1");
        });

        modelBuilder.Entity<Carritoproducto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("carritoproducto");

            entity.HasIndex(e => e.CarritoId, "CarritoId");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.HasOne(d => d.Carrito).WithMany(p => p.Carritoproducto)
                .HasForeignKey(d => d.CarritoId)
                .HasConstraintName("carritoproducto_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.Carritoproducto)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("carritoproducto_ibfk_2");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(90);
            entity.Property(e => e.NombreCategoria).HasMaxLength(90);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.BarrioId, "BarrioId");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.Telefono).HasMaxLength(50);

            entity.HasOne(d => d.Barrio).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.BarrioId)
                .HasConstraintName("cliente_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Cliente)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("cliente_ibfk_2");
        });

        modelBuilder.Entity<Clientenatural>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("clientenatural");

            entity.HasIndex(e => e.ClienteId, "ClienteId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(50);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(50);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Clientenatural)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("clientenatural_ibfk_1");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("credito");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.Property(e => e.FechaDesembolso).HasColumnType("datetime");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Credito)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("credito_ibfk_1");
        });

        modelBuilder.Entity<Cuota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cuota");

            entity.HasIndex(e => e.IdCredito, "IdCredito");

            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.FechaPagoProgramado).HasColumnType("datetime");

            entity.HasOne(d => d.IdCreditoNavigation).WithMany(p => p.Cuota)
                .HasForeignKey(d => d.IdCredito)
                .HasConstraintName("cuota_ibfk_1");
        });

        modelBuilder.Entity<Detallepedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detallepedido");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Detallepedido)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallepedido_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detallepedido)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detallepedido_ibfk_2");
        });

        modelBuilder.Entity<Direccionenvio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("direccionenvio");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.Ciudad).HasMaxLength(100);
            
            entity.Property(e => e.Departamento).HasMaxLength(100);
            entity.Property(e => e.Latitud).HasColumnType("decimal(10,8)");

            entity.Property(e => e.Longitud).HasColumnType("decimal(11,8)");

            entity.Property(e => e.Direccion).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Direccionenvio)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("direccionenvio_ibfk_1");
        });

        modelBuilder.Entity<Estadopedidohistorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estadopedidohistorial");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.Property(e => e.EstadoAnterior).HasMaxLength(50);
            entity.Property(e => e.EstadoNuevo).HasMaxLength(50);
            entity.Property(e => e.FechaCambio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Estadopedidohistorial)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("estadopedidohistorial_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("factura");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.Property(e => e.CodigoControl).HasMaxLength(90);
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.Qr).HasMaxLength(90);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Factura)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("factura_ibfk_1");
        });

        modelBuilder.Entity<Juridico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("juridico");

            entity.HasIndex(e => e.ClienteId, "ClienteId");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.RepresentanteLegal).HasMaxLength(100);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Juridico)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("juridico_ibfk_1");
        });

        modelBuilder.Entity<Lote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lote");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NroLote).HasMaxLength(50);
        });

        modelBuilder.Entity<Loteproducto>(entity =>
        {
            entity.HasKey(e => new { e.IdLote, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("loteproducto");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

            entity.HasOne(d => d.IdLoteNavigation).WithMany(p => p.Loteproducto)
                .HasForeignKey(d => d.IdLote)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loteproducto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Loteproducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loteproducto_ibfk_2");
        });

        modelBuilder.Entity<Notificacionusuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("notificacionusuario");

            entity.HasIndex(e => e.UsuarioId, "UsuarioId");

            entity.Property(e => e.FechaEnvio)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Leido).HasDefaultValueSql("'0'");
            entity.Property(e => e.Mensaje).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Notificacionusuario)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("notificacionusuario_ibfk_1");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pago");

            entity.HasIndex(e => e.IdPedido, "IdPedido");

            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.TipoPago).HasMaxLength(50);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pago)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pago_ibfk_1");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pedido");

            entity.HasIndex(e => e.DireccionEnvioId, "DireccionEnvioId");

            entity.HasIndex(e => e.IdCliente, "IdCliente");

            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Pendiente'");
            entity.Property(e => e.FechaPedido).HasColumnType("datetime");

            entity.HasOne(d => d.DireccionEnvio).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.DireccionEnvioId)
                .HasConstraintName("pedido_ibfk_2");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedido)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("pedido_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreProducto).HasMaxLength(90);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("producto_ibfk_1");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Direccion).HasMaxLength(90);
            entity.Property(e => e.NombreProveedor).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Proveedorproducto>(entity =>
        {
            entity.HasKey(e => new { e.IdProveedor, e.IdProducto })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("proveedorproducto");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.NombreEspecifico).HasMaxLength(50);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Proveedorproducto)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedorproducto_ibfk_2");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Proveedorproducto)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proveedorproducto_ibfk_1");
        });

        modelBuilder.Entity<Topproductosmasvendidos>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("topproductosmasvendidos");

            entity.Property(e => e.NombreProducto).HasMaxLength(90);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Correo, "Correo").IsUnique();

            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.TipoUsuario).HasMaxLength(20);
        });

        modelBuilder.Entity<VistaProductosmasvendidosporanio>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vista_productosmasvendidosporanio");

            entity.Property(e => e.NombreProducto).HasMaxLength(90);
        });

        modelBuilder.Entity<VwInformeventas>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_informeventas");

            entity.Property(e => e.CategoriaProducto).HasMaxLength(90);
            entity.Property(e => e.CiudadEnvio).HasMaxLength(100);
            entity.Property(e => e.DireccionCliente).HasMaxLength(255);
            entity.Property(e => e.DireccionEnvio).HasMaxLength(255);
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Pendiente'");
            entity.Property(e => e.FechaFactura).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimoPago).HasColumnType("datetime");
            entity.Property(e => e.HoraPedido).HasMaxLength(10);
            entity.Property(e => e.NombreCliente).HasMaxLength(100);
            entity.Property(e => e.NombreProducto).HasMaxLength(90);
            entity.Property(e => e.PedidoId).HasColumnName("PedidoID");
            entity.Property(e => e.TelefonoCliente).HasMaxLength(50);
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(8)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TipoUltimoPago).HasMaxLength(50);
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("zona");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.NombreZona).HasMaxLength(90);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
