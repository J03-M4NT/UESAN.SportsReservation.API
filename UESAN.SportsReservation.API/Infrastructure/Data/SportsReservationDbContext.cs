using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UESAN.SportsReservation.API.Infrastructure.Data;

public partial class SportsReservationDbContext : DbContext
{
    public SportsReservationDbContext()
    {
    }

    public SportsReservationDbContext(DbContextOptions<SportsReservationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Canchas> Canchas { get; set; }

    public virtual DbSet<Reservas> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LG15NKV;Database=SportsReservationDB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Canchas>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Ubicacion).HasMaxLength(100);
        });

        modelBuilder.Entity<Reservas>(entity =>
        {
            entity.Property(e => e.ClienteNombre).HasMaxLength(100);
            entity.Property(e => e.HoraFin).HasPrecision(0);
            entity.Property(e => e.HoraInicio).HasPrecision(0);

            entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.CanchaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reservas_Canchas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
