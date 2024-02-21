using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prueba_Iroute_Back.Infrastructure.Models;

public partial class PruebaIrouteDbContext : DbContext
{
    public PruebaIrouteDbContext()
    {
    }

    public PruebaIrouteDbContext(DbContextOptions<PruebaIrouteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClienteEntity> ClienteEntity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clienteE__3213E83FE6E0B1BD");

            entity.ToTable("clienteEntity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Identificacion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("identificacion");
            entity.Property(e => e.Mail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mail");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("primerNombre");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("segundoNombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
