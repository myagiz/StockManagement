using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entity;

public partial class StockManagementContext : DbContext
{
    public StockManagementContext()
    {
    }

    public StockManagementContext(DbContextOptions<StockManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockType> StockTypes { get; set; }

    public virtual DbSet<StockUnit> StockUnits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-63V1NH4\\SQLEXPRESS;Database=StockManagement;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stocks__3214EC07CD1E6B2F");

            entity.Property(e => e.CabinetInfo).HasMaxLength(100);
            entity.Property(e => e.CriticalQuantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShelfInfo).HasMaxLength(100);
        });

        modelBuilder.Entity<StockType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockTyp__C497F0FA80027C72");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<StockUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StockUni__3214EC07686D26B7");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Paperweight).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
