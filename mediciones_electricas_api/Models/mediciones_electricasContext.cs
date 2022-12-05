using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mediciones_electricas_api.Models
{
    public partial class mediciones_electricasContext : DbContext
    {
      
        public mediciones_electricasContext(DbContextOptions<mediciones_electricasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<EquiposEmpleado> EquiposEmpleados { get; set; } = null!;
        public virtual DbSet<EquiposProducto> EquiposProductos { get; set; } = null!;
        public virtual DbSet<LineaProduccion> LineaProduccions { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Orden> Ordens { get; set; } = null!;
        public virtual DbSet<OrdenProducto> OrdenProductos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Prueba> Pruebas { get; set; } = null!;
        public virtual DbSet<Puesto> Puestos { get; set; } = null!;
        public virtual DbSet<TestPlan> TestPlans { get; set; } = null!;
        public virtual DbSet<TipoPrueba> TipoPrueba { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Turno).HasColumnName("turno");

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdPuesto)
                    .HasConstraintName("FK__empleados__idPue__6C190EBB");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("equipos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

           modelBuilder.Entity<EquiposEmpleado>(entity =>
            {
                entity.ToTable("equiposEmpleado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EquiposEmpleados)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__equiposEm__idEmp__778AC167");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.EquiposEmpleados)
                    .HasForeignKey(d => d.IdEquipo)
                    .HasConstraintName("FK__equiposEm__idEqu__76969D2E");
            });

            modelBuilder.Entity<EquiposProducto>(entity =>
            {
                entity.ToTable("equiposProductos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.EquiposProductos)
                    .HasForeignKey(d => d.IdEquipo)
                    .HasConstraintName("FK__equiposPr__idEqu__6E01572D");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.EquiposProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__equiposPr__idPro__6EF57B66");
            });

            modelBuilder.Entity<LineaProduccion>(entity =>
            {
                entity.ToTable("lineaProduccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("area");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

               /* entity.Property(e => e.UltimaConexion)
                    .HasColumnType("datetime")
                    .HasColumnName("ultimaConexion");*/

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("modelos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.IdTestPlan).HasColumnName("idTestPlan");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__modelos__idProdu__68487DD7");

                entity.HasOne(d => d.IdTestPlanNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdTestPlan)
                    .HasConstraintName("FK__modelos__idTestP__693CA210");
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fechaEntrega");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fechaInicio");
            });

            modelBuilder.Entity<OrdenProducto>(entity =>
            {
                entity.ToTable("ordenProductos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.IdOrden).HasColumnName("idOrden");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.OrdenProductos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__ordenProd__idMod__7C4F7684");

                entity.HasOne(d => d.IdOrdenNavigation)
                    .WithMany(p => p.OrdenProductos)
                    .HasForeignKey(d => d.IdOrden)
                    .HasConstraintName("FK__ordenProd__idOrd__7A672E12");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.OrdenProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__ordenProd__idPro__7B5B524B");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Desviaciones)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("desviaciones");

                entity.Property(e => e.Especificaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("especificaciones");

                entity.Property(e => e.ListaParte).HasColumnName("listaParte");

                entity.Property(e => e.Procedimiento)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("procedimiento");
            });

            modelBuilder.Entity<Prueba>(entity =>
            {
                entity.ToTable("pruebas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.IdEquipo).HasColumnName("idEquipo");

                entity.Property(e => e.IdLineaProd).HasColumnName("idLineaProd");

                entity.Property(e => e.IdModelo).HasColumnName("idModelo");

                entity.Property(e => e.Resultado).HasColumnName("resultado");

                entity.Property(e => e.idTipoPrueba).HasColumnName("idTipoPrueba");

                entity.Property(e => e.Serie)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serie");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__pruebas__idEmple__72C60C4A");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.IdEquipo)
                    .HasConstraintName("FK__pruebas__idEquip__73BA3083");

                entity.HasOne(d => d.IdLineaProdNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.IdLineaProd)
                    .HasConstraintName("FK__pruebas__idLinea__71D1E811");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK__pruebas__idModel__70DDC3D8");

                entity.HasOne(d => d.IdTipoPruebaNavigation)
                    .WithMany(p => p.Pruebas)
                    .HasForeignKey(d => d.idTipoPrueba)
                    .HasConstraintName("FK__pruebas__idTipoP__5CD6CB2B");
            });

            modelBuilder.Entity<TipoPrueba>(entity =>
            {
                entity.ToTable("TipoPrueba");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("Descripcion")
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.ToTable("puestos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Salario)
                    .HasColumnType("money")
                    .HasColumnName("salario");
            });

            modelBuilder.Entity<TestPlan>(entity =>
            {
                entity.ToTable("testPlan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ruta)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ruta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
