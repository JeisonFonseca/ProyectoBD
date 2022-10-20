using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto.Models
{
    public partial class FincaLosLaurelesContext : DbContext
    {
        public FincaLosLaurelesContext()
        {
        }

        public FincaLosLaurelesContext(DbContextOptions<FincaLosLaurelesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adquisión> Adquisións { get; set; } = null!;
        public virtual DbSet<Ave> Aves { get; set; } = null!;
        public virtual DbSet<Bovino> Bovinos { get; set; } = null!;
        public virtual DbSet<BovinoProduccion> BovinoProduccions { get; set; } = null!;
        public virtual DbSet<Chancho> Chanchos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Encargado> Encargados { get; set; } = null!;
        public virtual DbSet<EncargadoAve> EncargadoAves { get; set; } = null!;
        public virtual DbSet<EncargadoChancho> EncargadoChanchos { get; set; } = null!;
        public virtual DbSet<EncargadoPerro> EncargadoPerros { get; set; } = null!;
        public virtual DbSet<EncargadoPropiedad> EncargadoPropiedads { get; set; } = null!;
        public virtual DbSet<Perro> Perros { get; set; } = null!;
        public virtual DbSet<ProduccionLeche> ProduccionLeches { get; set; } = null!;
        public virtual DbSet<Propiedad> Propiedads { get; set; } = null!;
        public virtual DbSet<PropiedadesBovinosDueno> PropiedadesBovinosDuenos { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<VistaBovino> VistaBovinos { get; set; } = null!;
        public virtual DbSet<VistaPropiedadDueno> VistaPropiedadDuenos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-RIB9CLGL;Database=FincaLosLaureles;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adquisión>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__Adquisió__F2374EB1BC18470B");

                entity.ToTable("Adquisión");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ave>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__Ave__75E3EFCE5D8CE790");

                entity.ToTable("Ave");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.Property(e => e.Raza)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Aves)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ave__Sexo__6FE99F9F");
            });

            modelBuilder.Entity<Bovino>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__Bovino__F2374EB15025A704");

                entity.ToTable("Bovino");

                entity.Property(e => e.Identificador).ValueGeneratedNever();

                entity.Property(e => e.FechaMonta).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.MadreNavigation)
                    .WithMany(p => p.InverseMadreNavigation)
                    .HasForeignKey(d => d.Madre)
                    .HasConstraintName("FK__Bovino__Madre__4D94879B");

                entity.HasOne(d => d.PadreNavigation)
                    .WithMany(p => p.InversePadreNavigation)
                    .HasForeignKey(d => d.Padre)
                    .HasConstraintName("FK__Bovino__Padre__4E88ABD4");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Bovinos)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bovino__Sexo__4CA06362");

                entity.HasOne(d => d.TipoAdquisiciónNavigation)
                    .WithMany(p => p.Bovinos)
                    .HasForeignKey(d => d.TipoAdquisición)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bovino__TipoAdqu__4F7CD00D");
            });

            modelBuilder.Entity<BovinoProduccion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BovinoProduccion");

                entity.HasOne(d => d.IdentificadorBovinoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdentificadorBovino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BovinoPro__Ident__5CD6CB2B");

                entity.HasOne(d => d.IdentificadorProduccionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdentificadorProduccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BovinoPro__Ident__5DCAEF64");
            });

            modelBuilder.Entity<Chancho>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__Chancho__75E3EFCEF66A30BD");

                entity.ToTable("Chancho");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Chanchos)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chancho__Sexo__68487DD7");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Empleado__B4ADFE39223613F0");

                entity.ToTable("Empleado");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Apellido 1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Apellido 2");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Rol)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Encargado>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Encargad__B4ADFE39C9565F48");

                entity.ToTable("Encargado");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Apellido 1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Apellido 2");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasMany(d => d.CedulaEmpleados)
                    .WithMany(p => p.CedulaEncargados)
                    .UsingEntity<Dictionary<string, object>>(
                        "EncargadoEmpleado",
                        l => l.HasOne<Empleado>().WithMany().HasForeignKey("CedulaEmpleado").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Encargado__Cedul__33D4B598"),
                        r => r.HasOne<Encargado>().WithMany().HasForeignKey("CedulaEncargado").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Encargado__Cedul__32E0915F"),
                        j =>
                        {
                            j.HasKey("CedulaEncargado", "CedulaEmpleado").HasName("PK__Encargad__DEC0AAD1F9EBDACB");

                            j.ToTable("Encargado_Empleado");

                            j.IndexerProperty<string>("CedulaEncargado").HasMaxLength(10).IsUnicode(false);

                            j.IndexerProperty<string>("CedulaEmpleado").HasMaxLength(10).IsUnicode(false);
                        });

                entity.HasMany(d => d.IdentificadorBovinos)
                    .WithMany(p => p.CedulaEncargados)
                    .UsingEntity<Dictionary<string, object>>(
                        "EncargadoBovino",
                        l => l.HasOne<Bovino>().WithMany().HasForeignKey("IdentificadorBovino").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Encargado__Ident__0C85DE4D"),
                        r => r.HasOne<Encargado>().WithMany().HasForeignKey("CedulaEncargado").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Encargado__Cedul__0B91BA14"),
                        j =>
                        {
                            j.HasKey("CedulaEncargado", "IdentificadorBovino").HasName("PK__Encargad__F47BA14362E6B55E");

                            j.ToTable("EncargadoBovino");

                            j.IndexerProperty<string>("CedulaEncargado").HasMaxLength(10).IsUnicode(false);
                        });
            });

            modelBuilder.Entity<EncargadoAve>(entity =>
            {
                entity.HasKey(e => e.CedulaEncargado)
                    .HasName("PK__Encargad__B28BCA2443B6CF22");

                entity.ToTable("EncargadoAve");

                entity.Property(e => e.CedulaEncargado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.Property(e => e.IdentificadorPerro)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaEncargadoNavigation)
                    .WithOne(p => p.EncargadoAve)
                    .HasForeignKey<EncargadoAve>(d => d.CedulaEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Cedul__72C60C4A");

                entity.HasOne(d => d.IdentificadorPerroNavigation)
                    .WithMany(p => p.EncargadoAves)
                    .HasForeignKey(d => d.IdentificadorPerro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Ident__73BA3083");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.EncargadoAves)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EncargadoA__Sexo__74AE54BC");
            });

            modelBuilder.Entity<EncargadoChancho>(entity =>
            {
                entity.HasKey(e => e.CedulaEncargado)
                    .HasName("PK__Encargad__B28BCA245C15B1E7");

                entity.ToTable("EncargadoChancho");

                entity.Property(e => e.CedulaEncargado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.Property(e => e.IdentificadorPerro)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaEncargadoNavigation)
                    .WithOne(p => p.EncargadoChancho)
                    .HasForeignKey<EncargadoChancho>(d => d.CedulaEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Cedul__6B24EA82");

                entity.HasOne(d => d.IdentificadorPerroNavigation)
                    .WithMany(p => p.EncargadoChanchos)
                    .HasForeignKey(d => d.IdentificadorPerro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Ident__6C190EBB");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.EncargadoChanchos)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EncargadoC__Sexo__6D0D32F4");
            });

            modelBuilder.Entity<EncargadoPerro>(entity =>
            {
                entity.HasKey(e => e.CedulaEncargado)
                    .HasName("PK__Encargad__B28BCA24219E64F5");

                entity.ToTable("EncargadoPerro");

                entity.Property(e => e.CedulaEncargado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.Property(e => e.IdentificadorPerro)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaEncargadoNavigation)
                    .WithOne(p => p.EncargadoPerro)
                    .HasForeignKey<EncargadoPerro>(d => d.CedulaEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Cedul__6383C8BA");

                entity.HasOne(d => d.IdentificadorPerroNavigation)
                    .WithMany(p => p.EncargadoPerros)
                    .HasForeignKey(d => d.IdentificadorPerro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Ident__6477ECF3");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.EncargadoPerros)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EncargadoP__Sexo__656C112C");
            });

            modelBuilder.Entity<EncargadoPropiedad>(entity =>
            {
                entity.HasKey(e => e.CodigoPropiedad)
                    .HasName("PK__Encargad__7B4CCF4319065B45");

                entity.ToTable("EncargadoPropiedad");

                entity.Property(e => e.CodigoPropiedad).ValueGeneratedNever();

                entity.Property(e => e.CedulaEncargado)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaEncargadoNavigation)
                    .WithMany(p => p.EncargadoPropiedads)
                    .HasForeignKey(d => d.CedulaEncargado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Cedul__07C12930");

                entity.HasOne(d => d.CodigoPropiedadNavigation)
                    .WithOne(p => p.EncargadoPropiedad)
                    .HasForeignKey<EncargadoPropiedad>(d => d.CodigoPropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Encargado__Codig__08B54D69");
            });

            modelBuilder.Entity<Perro>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__Perro__75E3EFCE46146F55");

                entity.ToTable("Perro");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaLlegada).HasColumnType("date");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.Perros)
                    .HasForeignKey(d => d.Sexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Perro__Sexo__60A75C0F");
            });

            modelBuilder.Entity<ProduccionLeche>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__Producci__F2374EB139BBDB18");

                entity.ToTable("ProduccionLeche");
            });

            modelBuilder.Entity<Propiedad>(entity =>
            {
                entity.HasKey(e => e.CodigoEscritura)
                    .HasName("PK__Propieda__1C46E9E0D9846A83");

                entity.ToTable("Propiedad");

                entity.Property(e => e.CodigoEscritura).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra).HasColumnType("date");
            });

            modelBuilder.Entity<PropiedadesBovinosDueno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PropiedadesBovinosDuenos");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__Sexo__F2374EB1BFCC2FA8");

                entity.ToTable("Sexo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VistaBovino>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaBovinos");

                entity.Property(e => e.FechaMonta).HasColumnType("date");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Raza)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VistaPropiedadDueno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaPropiedadDueno");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
