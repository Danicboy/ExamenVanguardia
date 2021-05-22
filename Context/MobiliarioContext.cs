using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Examen1Reservas.Models.DBModels;

#nullable disable

namespace Examen1Reservas.Context
{
    public partial class MobiliarioContext : DbContext
    {
        public MobiliarioContext()
        {
        }

        public MobiliarioContext(DbContextOptions<MobiliarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Mobiliario> Mobiliarios { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QT843M6G\\MSSQLSERVER01;Database=MobiliarioDB;user id=sa; password=Supermario1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.Mobiliario)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.MobiliarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Mobiliario");
            });

            modelBuilder.Entity<Mobiliario>(entity =>
            {
                entity.ToTable("Mobiliario");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.ToTable("Reserva");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Cliente");

                entity.HasOne(d => d.Evento)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.EventoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Evento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
