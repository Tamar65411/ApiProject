using System;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository;

public partial class StoreDataBase2Context : DbContext
{
    public IConfiguration _configuration { get; }
    public StoreDataBase2Context()
    {
    }

    public StoreDataBase2Context(DbContextOptions<StoreDataBase2Context> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<OrderItemTbl> OrderItemTbls { get; set; }

    public virtual DbSet<OrdersTbl> OrdersTbls { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }
    public virtual DbSet<Rating> Ratings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("connectDB"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<OrderItemTbl>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);

            entity.ToTable("OrderItem_tbl");

            entity.Property(e => e.OrderItemId).HasColumnName("orderItemId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quentity)
                .HasDefaultValueSql("((1))")
                .HasColumnName("quentity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderItem_tbl_Orders_tbl");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItemTbls)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderItem_tbl_Product");
        });

        modelBuilder.Entity<OrdersTbl>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Orders_tbl");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.OrderDate)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("orderDate");
            entity.Property(e => e.OrderSum).HasColumnName("orderSum");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.OrdersTbls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_tbl_Users_tbl");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Image)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("Users_tbl");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("password");
        });
        modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                 .HasColumnName("Record_Date")
                 .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
