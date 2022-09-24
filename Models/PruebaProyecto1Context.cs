using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto.Models
{
    public partial class PruebaProyecto1Context : DbContext
    {
        public PruebaProyecto1Context()
        {
        }

        public PruebaProyecto1Context(DbContextOptions<PruebaProyecto1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ActividadCaso> ActividadCasos { get; set; } = null!;
        public virtual DbSet<ActividadCliente> ActividadClientes { get; set; } = null!;
        public virtual DbSet<ActividadContacto> ActividadContactos { get; set; } = null!;
        public virtual DbSet<ActividadCotizacion> ActividadCotizacions { get; set; } = null!;
        public virtual DbSet<ActividadEjecucion> ActividadEjecucions { get; set; } = null!;
        public virtual DbSet<Caso> Casos { get; set; } = null!;
        public virtual DbSet<CasoEjecucion> CasoEjecucions { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<ContactoCliente> ContactoClientes { get; set; } = null!;
        public virtual DbSet<Cotizacion> Cotizacions { get; set; } = null!;
        public virtual DbSet<CotizacionCliente> CotizacionClientes { get; set; } = null!;
        public virtual DbSet<CotizacionEjecucion> CotizacionEjecucions { get; set; } = null!;
        public virtual DbSet<CotizacionProducto> CotizacionProductos { get; set; } = null!;
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<Ejecucion> Ejecucions { get; set; } = null!;
        public virtual DbSet<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; } = null!;
        public virtual DbSet<EstadoCaso> EstadoCasos { get; set; } = null!;
        public virtual DbSet<EstadoContacto> EstadoContactos { get; set; } = null!;
        public virtual DbSet<EstadoTarea> EstadoTareas { get; set; } = null!;
        public virtual DbSet<EtapaCotizacion> EtapaCotizacions { get; set; } = null!;
        public virtual DbSet<FamiliaProducto> FamiliaProductos { get; set; } = null!;
        public virtual DbSet<Inflacion> Inflacions { get; set; } = null!;
        public virtual DbSet<ManagerDepartamento> ManagerDepartamentos { get; set; } = null!;
        public virtual DbSet<Monedum> Moneda { get; set; } = null!;
        public virtual DbSet<MotivoContacto> MotivoContactos { get; set; } = null!;
        public virtual DbSet<OrigenCaso> OrigenCasos { get; set; } = null!;
        public virtual DbSet<PorQueSeDenego> PorQueSeDenegos { get; set; } = null!;
        public virtual DbSet<Prioridad> Prioridads { get; set; } = null!;
        public virtual DbSet<Probabilidad> Probabilidads { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<Sector> Sectors { get; set; } = null!;
        public virtual DbSet<TareaCaso> TareaCasos { get; set; } = null!;
        public virtual DbSet<TareaCliente> TareaClientes { get; set; } = null!;
        public virtual DbSet<TareaContacto> TareaContactos { get; set; } = null!;
        public virtual DbSet<TareaCotizacion> TareaCotizacions { get; set; } = null!;
        public virtual DbSet<TareaEjecucion> TareaEjecucions { get; set; } = null!;
        public virtual DbSet<TipoCaso> TipoCasos { get; set; } = null!;
        public virtual DbSet<TipoContacto> TipoContactos { get; set; } = null!;
        public virtual DbSet<TipoCotizacion> TipoCotizacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Zona> Zonas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-RIB9CLGL; Database=PruebaProyecto#1; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadCaso>(entity =>
            {
                entity.ToTable("ActividadCaso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ActividadCasos)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Aseso__40C49C62");

                entity.HasOne(d => d.CasoNavigation)
                    .WithMany(p => p.ActividadCasos)
                    .HasForeignKey(d => d.Caso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActividadC__Caso__3FD07829");
            });

            modelBuilder.Entity<ActividadCliente>(entity =>
            {
                entity.ToTable("ActividadCliente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ActividadClientes)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Aseso__2704CA5F");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.ActividadClientes)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Clien__2610A626");
            });

            modelBuilder.Entity<ActividadContacto>(entity =>
            {
                entity.ToTable("ActividadContacto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ActividadContactos)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Aseso__019E3B86");

                entity.HasOne(d => d.ContactoNavigation)
                    .WithMany(p => p.ActividadContactos)
                    .HasForeignKey(d => d.Contacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Conta__00AA174D");
            });

            modelBuilder.Entity<ActividadCotizacion>(entity =>
            {
                entity.ToTable("ActividadCotizacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ActividadCotizacions)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Aseso__6E8B6712");

                entity.HasOne(d => d.CotizacionNavigation)
                    .WithMany(p => p.ActividadCotizacions)
                    .HasForeignKey(d => d.Cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Cotiz__6D9742D9");
            });

            modelBuilder.Entity<ActividadEjecucion>(entity =>
            {
                entity.ToTable("ActividadEjecucion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ActividadEjecucions)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Aseso__382F5661");

                entity.HasOne(d => d.EjecucionNavigation)
                    .WithMany(p => p.ActividadEjecucions)
                    .HasForeignKey(d => d.Ejecucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Actividad__Ejecu__373B3228");
            });

            modelBuilder.Entity<Caso>(entity =>
            {
                entity.ToTable("Caso");

                entity.Property(e => e.Asunto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreContacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DireccionNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.Direccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__Direccion__0A688BB1");

                entity.HasOne(d => d.EstadoCasoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.EstadoCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__EstadoCaso__09746778");

                entity.HasOne(d => d.OrigenCasoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.OrigenCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__OrigenCaso__0880433F");

                entity.HasOne(d => d.PrioridadNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.Prioridad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__Prioridad__0C50D423");

                entity.HasOne(d => d.PropietarioCasoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.PropietarioCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__Propietari__078C1F06");

                entity.HasOne(d => d.TipoCasoNavigation)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.TipoCaso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Caso__TipoCaso__0B5CAFEA");
            });

            modelBuilder.Entity<CasoEjecucion>(entity =>
            {
                entity.HasKey(e => e.Proyecto)
                    .HasName("PK__CasoEjec__A79B8EB76FA3A98E");

                entity.ToTable("CasoEjecucion");

                entity.Property(e => e.Proyecto).ValueGeneratedNever();

                entity.HasOne(d => d.CasoNavigation)
                    .WithMany(p => p.CasoEjecucions)
                    .HasForeignKey(d => d.Caso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CasoEjecuc__Caso__11158940");

                entity.HasOne(d => d.ProyectoNavigation)
                    .WithOne(p => p.CasoEjecucion)
                    .HasForeignKey<CasoEjecucion>(d => d.Proyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CasoEjecu__Proye__10216507");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Cliente__B4ADFE3934E022AA");

                entity.ToTable("Cliente");

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.ContactoPrincipal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InformacionAdicional)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SitioWeb)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Asesor__25518C17");

                entity.HasOne(d => d.MonedaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Moneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Moneda__22751F6C");

                entity.HasOne(d => d.SectorNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Sector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Sector__236943A5");

                entity.HasOne(d => d.ZonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Zona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__Zona__245D67DE");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__Client__395884C4");

                entity.HasOne(d => d.DireccionNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.Direccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__Direcc__3C34F16F");

                entity.HasOne(d => d.MotivoContactoNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.MotivoContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__Motivo__3B40CD36");

                entity.HasOne(d => d.SectorNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.Sector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__Sector__3D2915A8");

                entity.HasOne(d => d.TipoContactoNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.TipoContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__TipoCo__3A4CA8FD");

                entity.HasOne(d => d.ZonaNavigation)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.Zona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__Zona__3E1D39E1");
            });

            modelBuilder.Entity<ContactoCliente>(entity =>
            {
                entity.HasKey(e => e.Contacto)
                    .HasName("PK__Contacto__CFEC40CC2C307C81");

                entity.ToTable("ContactoCliente");

                entity.Property(e => e.Contacto).ValueGeneratedNever();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.ContactoClientes)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactoC__Aseso__5F7E2DAC");

                entity.HasOne(d => d.ContactoNavigation)
                    .WithOne(p => p.ContactoCliente)
                    .HasForeignKey<ContactoCliente>(d => d.Contacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactoC__Conta__5E8A0973");

                entity.HasOne(d => d.EstadoContactoNavigation)
                    .WithMany(p => p.ContactoClientes)
                    .HasForeignKey(d => d.EstadoContacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContactoC__Estad__607251E5");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.CodigoCotizacion)
                    .HasName("PK__Cotizaci__9DC346CC36A6DEC1");

                entity.ToTable("Cotizacion");

                entity.Property(e => e.ContraQuien)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Factura).HasColumnName("#Factura");

                entity.Property(e => e.FechaCierreReal).HasColumnType("date");

                entity.Property(e => e.FechaCotizacion).HasColumnType("date");

                entity.Property(e => e.MesAnnoPrytadoCierre)
                    .HasColumnType("date")
                    .HasColumnName("Mes_Anno_PrytadoCierre");

                entity.Property(e => e.NombreCotizacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.EtapaCotizaNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.EtapaCotiza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Etapa__54CB950F");

                entity.HasOne(d => d.MonedaNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Moneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Moned__55BFB948");

                entity.HasOne(d => d.PorqueSeDenegoNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.PorqueSeDenego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Porqu__589C25F3");

                entity.HasOne(d => d.ProbabilidadNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.Probabilidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Proba__56B3DD81");

                entity.HasOne(d => d.TipoCotizacionNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.TipoCotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__TipoC__57A801BA");
            });

            modelBuilder.Entity<CotizacionCliente>(entity =>
            {
                entity.HasKey(e => new { e.Cotizacion, e.Asesor, e.Cliente })
                    .HasName("PK__Cotizaci__D8319D082FB2CAFB");

                entity.ToTable("CotizacionCliente");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.CotizacionClientes)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Aseso__5C6CB6D7");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.CotizacionClientes)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Clien__5D60DB10");

                entity.HasOne(d => d.CotizacionNavigation)
                    .WithMany(p => p.CotizacionClientes)
                    .HasForeignKey(d => d.Cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Cotiz__5B78929E");
            });

            modelBuilder.Entity<CotizacionEjecucion>(entity =>
            {
                entity.HasKey(e => e.Cotizacion)
                    .HasName("PK__Cotizaci__40D6AEAAE2633093");

                entity.ToTable("CotizacionEjecucion");

                entity.Property(e => e.Cotizacion)
                    .ValueGeneratedNever()
                    .HasColumnName("#Cotizacion");

                entity.Property(e => e.Ejecucion).HasColumnName("#Ejecucion");

                entity.HasOne(d => d.CotizacionNavigation)
                    .WithOne(p => p.CotizacionEjecucion)
                    .HasForeignKey<CotizacionEjecucion>(d => d.Cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__#Coti__6501FCD8");

                entity.HasOne(d => d.EjecucionNavigation)
                    .WithMany(p => p.CotizacionEjecucions)
                    .HasForeignKey(d => d.Ejecucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__#Ejec__65F62111");
            });

            modelBuilder.Entity<CotizacionProducto>(entity =>
            {
                entity.HasKey(e => new { e.CodigoProducto, e.Cotizacion })
                    .HasName("PK__Cotizaci__6DD79B2C418167ED");

                entity.ToTable("CotizacionProducto");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.CotizacionProductos)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Codig__61316BF4");

                entity.HasOne(d => d.CotizacionNavigation)
                    .WithMany(p => p.CotizacionProductos)
                    .HasForeignKey(d => d.Cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cotizacio__Cotiz__603D47BB");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodigoDepartamento)
                    .HasName("PK__Departam__60D0E0795452AF0F");

                entity.ToTable("Departamento");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("Codigo_departamento");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion");

                entity.Property(e => e.Canton)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sennas)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ejecucion>(entity =>
            {
                entity.ToTable("Ejecucion");

                entity.Property(e => e.FechaCierreReal).HasColumnType("date");

                entity.Property(e => e.FechaEjecucion).HasColumnType("date");

                entity.Property(e => e.MAProyCierre)
                    .HasColumnType("date")
                    .HasColumnName("M_A_Proy_Cierre");

                entity.Property(e => e.NombreEjecucion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.EjecucionAsesorNavigations)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ejecucion__Aseso__7EF6D905");

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.Ejecucions)
                    .HasForeignKey(d => d.Departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ejecucion__Depar__7D0E9093");

                entity.HasOne(d => d.PropietarioEjecucionNavigation)
                    .WithMany(p => p.EjecucionPropietarioEjecucionNavigations)
                    .HasForeignKey(d => d.PropietarioEjecucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ejecucion__Propi__7E02B4CC");
            });

            modelBuilder.Entity<EmpleadoDepartamento>(entity =>
            {
                entity.HasKey(e => e.CedulaEmpleado)
                    .HasName("PK__Empleado__F18B582916BB4257");

                entity.ToTable("Empleado_Departamento");

                entity.Property(e => e.CedulaEmpleado)
                    .ValueGeneratedNever()
                    .HasColumnName("Cedula_empleado");

                entity.Property(e => e.CodigoDepartamento).HasColumnName("Codigo_departamento");

                entity.HasOne(d => d.CedulaEmpleadoNavigation)
                    .WithOne(p => p.EmpleadoDepartamento)
                    .HasForeignKey<EmpleadoDepartamento>(d => d.CedulaEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___Cedul__17036CC0");

                entity.HasOne(d => d.CodigoDepartamentoNavigation)
                    .WithMany(p => p.EmpleadoDepartamentos)
                    .HasForeignKey(d => d.CodigoDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Empleado___Codig__17F790F9");
            });

            modelBuilder.Entity<EstadoCaso>(entity =>
            {
                entity.ToTable("EstadoCaso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoContacto>(entity =>
            {
                entity.ToTable("EstadoContacto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoTarea>(entity =>
            {
                entity.ToTable("EstadoTarea");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EtapaCotizacion>(entity =>
            {
                entity.ToTable("EtapaCotizacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FamiliaProducto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__FamiliaP__06370DADEB251CEA");

                entity.ToTable("FamiliaProducto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inflacion>(entity =>
            {
                entity.ToTable("Inflacion");
            });

            modelBuilder.Entity<ManagerDepartamento>(entity =>
            {
                entity.HasKey(e => e.CodigoDepartamento)
                    .HasName("PK__Manager___60D0E07962E8DE55");

                entity.ToTable("Manager_Departamento");

                entity.Property(e => e.CodigoDepartamento)
                    .ValueGeneratedNever()
                    .HasColumnName("Codigo_departamento");

                entity.Property(e => e.CedulaEmpleadoManager).HasColumnName("Cedula_empleado_manager");

                entity.HasOne(d => d.CedulaEmpleadoManagerNavigation)
                    .WithMany(p => p.ManagerDepartamentos)
                    .HasForeignKey(d => d.CedulaEmpleadoManager)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Manager_D__Cedul__1332DBDC");

                entity.HasOne(d => d.CodigoDepartamentoNavigation)
                    .WithOne(p => p.ManagerDepartamento)
                    .HasForeignKey<ManagerDepartamento>(d => d.CodigoDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Manager_D__Codig__14270015");
            });

            modelBuilder.Entity<Monedum>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MotivoContacto>(entity =>
            {
                entity.ToTable("MotivoContacto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrigenCaso>(entity =>
            {
                entity.ToTable("OrigenCaso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PorQueSeDenego>(entity =>
            {
                entity.ToTable("PorQueSeDenego");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prioridad>(entity =>
            {
                entity.ToTable("Prioridad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Probabilidad>(entity =>
            {
                entity.ToTable("Probabilidad");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Producto__06370DAD17B0F05B");

                entity.ToTable("Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FamiliaProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.FamiliaProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__Famili__0E6E26BF");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sector>(entity =>
            {
                entity.ToTable("Sector");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TareaCaso>(entity =>
            {
                entity.ToTable("TareaCaso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.TareaCasos)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCaso__Aseso__3CF40B7E");

                entity.HasOne(d => d.CasoNavigation)
                    .WithMany(p => p.TareaCasos)
                    .HasForeignKey(d => d.Caso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCaso__Caso__3B0BC30C");

                entity.HasOne(d => d.EstadoTareaNavigation)
                    .WithMany(p => p.TareaCasos)
                    .HasForeignKey(d => d.EstadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCaso__Estad__3BFFE745");
            });

            modelBuilder.Entity<TareaCliente>(entity =>
            {
                entity.ToTable("TareaCliente");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.TareaClientes)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaClie__Aseso__2334397B");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.TareaClientes)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaClie__Clien__214BF109");

                entity.HasOne(d => d.EstadoTareaNavigation)
                    .WithMany(p => p.TareaClientes)
                    .HasForeignKey(d => d.EstadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaClie__Estad__22401542");
            });

            modelBuilder.Entity<TareaContacto>(entity =>
            {
                entity.ToTable("TareaContacto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.TareaContactos)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCont__Aseso__7DCDAAA2");

                entity.HasOne(d => d.ContactoNavigation)
                    .WithMany(p => p.TareaContactos)
                    .HasForeignKey(d => d.Contacto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCont__Conta__7BE56230");

                entity.HasOne(d => d.EstadoTareaNavigation)
                    .WithMany(p => p.TareaContactos)
                    .HasForeignKey(d => d.EstadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCont__Estad__7CD98669");
            });

            modelBuilder.Entity<TareaCotizacion>(entity =>
            {
                entity.ToTable("TareaCotizacion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.TareaCotizacions)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCoti__Aseso__6ABAD62E");

                entity.HasOne(d => d.CotizacionNavigation)
                    .WithMany(p => p.TareaCotizacions)
                    .HasForeignKey(d => d.Cotizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCoti__Cotiz__68D28DBC");

                entity.HasOne(d => d.EstadoTareaNavigation)
                    .WithMany(p => p.TareaCotizacions)
                    .HasForeignKey(d => d.EstadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaCoti__Estad__69C6B1F5");
            });

            modelBuilder.Entity<TareaEjecucion>(entity =>
            {
                entity.ToTable("TareaEjecucion");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFinalizacion).HasColumnType("date");

                entity.HasOne(d => d.AsesorNavigation)
                    .WithMany(p => p.TareaEjecucions)
                    .HasForeignKey(d => d.Asesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaEjec__Aseso__345EC57D");

                entity.HasOne(d => d.EjecucionNavigation)
                    .WithMany(p => p.TareaEjecucions)
                    .HasForeignKey(d => d.Ejecucion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaEjec__Ejecu__32767D0B");

                entity.HasOne(d => d.EstadoTareaNavigation)
                    .WithMany(p => p.TareaEjecucions)
                    .HasForeignKey(d => d.EstadoTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TareaEjec__Estad__336AA144");
            });

            modelBuilder.Entity<TipoCaso>(entity =>
            {
                entity.ToTable("TipoCaso");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoContacto>(entity =>
            {
                entity.ToTable("TipoContacto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCotizacion>(entity =>
            {
                entity.ToTable("TipoCotizacion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Usuario__B4ADFE39DE95715C");

                entity.ToTable("Usuario");

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apelllido2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__Rol__08B54D69");
            });

            modelBuilder.Entity<Zona>(entity =>
            {
                entity.ToTable("Zona");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
