using System;
using System.Collections.Generic;
using DepartmentStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartmentStoreApp.Data;

public partial class DepartmentStoreDbContext : DbContext
{
    public DepartmentStoreDbContext()
    {
    }

    public DepartmentStoreDbContext(DbContextOptions<DepartmentStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderSource> OrderSources { get; set; }

    public virtual DbSet<Shipment> Shipments { get; set; }

    public virtual DbSet<ShipmentLine> ShipmentLines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__category__DD5DDDBD668AAC95");

            entity.ToTable("category");

            entity.Property(e => e.CatId)
                .ValueGeneratedNever()
                .HasColumnName("cat_id");
            entity.Property(e => e.CatDesc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cat_desc");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Color1).HasName("PK__color__900DC6E8FC7B0A5C");

            entity.ToTable("color");

            entity.Property(e => e.Color1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("color");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__customer__213EE77451127395");

            entity.ToTable("customer");

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("c_id");
            entity.Property(e => e.CAddress)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_address");
            entity.Property(e => e.CBirthdate).HasColumnName("c_birthdate");
            entity.Property(e => e.CCity)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_city");
            entity.Property(e => e.CDphone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_dphone");
            entity.Property(e => e.CEphone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_ephone");
            entity.Property(e => e.CFirst)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_first");
            entity.Property(e => e.CLast)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("c_last");
            entity.Property(e => e.CMi)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_mi");
            entity.Property(e => e.CPassword)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("c_password");
            entity.Property(e => e.CState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("c_state");
            entity.Property(e => e.CUserid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("c_userid");
            entity.Property(e => e.CZip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("c_zip");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InvId).HasName("PK__inventor__A8749C29DB0CF8F1");

            entity.ToTable("inventory");

            entity.Property(e => e.InvId)
                .ValueGeneratedNever()
                .HasColumnName("inv_id");
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.InvPrice)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("inv_price");
            entity.Property(e => e.InvQoh).HasColumnName("inv_qoh");
            entity.Property(e => e.InvSize)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("inv_size");
            entity.Property(e => e.ItemId).HasColumnName("item_id");

            entity.HasOne(d => d.ColorNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.Color)
                .HasConstraintName("FK__inventory__color__33D4B598");

            entity.HasOne(d => d.Item).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__inventory__item___32E0915F");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__item__52020FDD0E9617AA");

            entity.ToTable("item");

            entity.Property(e => e.ItemId)
                .ValueGeneratedNever()
                .HasColumnName("item_id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.ItemDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("item_desc");
            entity.Property(e => e.ItemImage).HasColumnName("item_image");

            entity.HasOne(d => d.Cat).WithMany(p => p.Items)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK__item__cat_id__2E1BDC42");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK__orders__904BC20E0A794046");

            entity.ToTable("orders");

            entity.Property(e => e.OId)
                .ValueGeneratedNever()
                .HasColumnName("o_id");
            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.ODate).HasColumnName("o_date");
            entity.Property(e => e.OMethpmt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("o_methpmt");
            entity.Property(e => e.OsId).HasColumnName("os_id");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__orders__c_id__286302EC");

            entity.HasOne(d => d.Os).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OsId)
                .HasConstraintName("FK__orders__os_id__29572725");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => new { e.OId, e.InvId }).HasName("PK__order_li__1ACC8BCC4D3707E4");

            entity.ToTable("order_line");

            entity.Property(e => e.OId).HasColumnName("o_id");
            entity.Property(e => e.InvId).HasColumnName("inv_id");
            entity.Property(e => e.OlQuantity).HasColumnName("ol_quantity");

            entity.HasOne(d => d.Inv).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.InvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_lin__inv_i__3D5E1FD2");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order_line__o_id__3C69FB99");
        });

        modelBuilder.Entity<OrderSource>(entity =>
        {
            entity.HasKey(e => e.OsId).HasName("PK__order_so__374FA4B51AB5D3DE");

            entity.ToTable("order_source");

            entity.Property(e => e.OsId)
                .ValueGeneratedNever()
                .HasColumnName("os_id");
            entity.Property(e => e.OsDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("os_desc");
        });

        modelBuilder.Entity<Shipment>(entity =>
        {
            entity.HasKey(e => e.ShipId).HasName("PK__shipment__CCF471DAC74E9985");

            entity.ToTable("shipment");

            entity.Property(e => e.ShipId)
                .ValueGeneratedNever()
                .HasColumnName("ship_id");
            entity.Property(e => e.ShipDateExpected).HasColumnName("ship_date_expected");
        });

        modelBuilder.Entity<ShipmentLine>(entity =>
        {
            entity.HasKey(e => new { e.ShipId, e.InvId }).HasName("PK__shipment__46733818066E22B4");

            entity.ToTable("shipment_line");

            entity.Property(e => e.ShipId).HasColumnName("ship_id");
            entity.Property(e => e.InvId).HasColumnName("inv_id");
            entity.Property(e => e.SlDateReceived).HasColumnName("sl_date_received");
            entity.Property(e => e.SlQuantity).HasColumnName("sl_quantity");

            entity.HasOne(d => d.Inv).WithMany(p => p.ShipmentLines)
                .HasForeignKey(d => d.InvId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shipment___inv_i__398D8EEE");

            entity.HasOne(d => d.Ship).WithMany(p => p.ShipmentLines)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__shipment___ship___38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
