using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BirdCageShop.DataAccess.Models
{
    public partial class BirdCageShopContext : DbContext
    {
        public BirdCageShopContext()
        {
        }

        public BirdCageShopContext(DbContextOptions<BirdCageShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BirdTypeCategory> BirdTypeCategories { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductEquipment> ProductEquipments { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=BirdCageShop;User ID=SA;Password=Vitamin123!@#");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BirdTypeCategory>(entity =>
            {
                entity.HasKey(e => e.BirdTypeId);

                entity.ToTable("BirdTypeCategory");

                entity.Property(e => e.BirdTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentId)
                    .HasMaxLength(200)
                    .HasColumnName("EquipmentID");

                entity.Property(e => e.Charge).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Type).HasMaxLength(200);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.NotificationId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NotificationID");

                entity.Property(e => e.Body).HasColumnType("ntext");

                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(200)
                    .HasColumnName("OrderID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AssignedEmp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.Country).HasMaxLength(200);

                entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

                entity.Property(e => e.Method)
                    .HasMaxLength(50)
                    .HasColumnName("method");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.State).HasMaxLength(200);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Voucher)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId)
                    .HasMaxLength(200)
                    .HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(200)
                    .HasColumnName("OrderID");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__59063A47");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__OrderDeta__Produ__59FA5E80");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(200)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Cvv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpirationDate).HasMaxLength(10);

                entity.Property(e => e.OrderId)
                    .HasMaxLength(200)
                    .HasColumnName("OrderID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.HasOne(d => d.PaymentNavigation)
                    .WithOne(p => p.Payment)
                    .HasForeignKey<Payment>(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Model).HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductMaterial).HasMaxLength(100);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.Sale).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.BirdType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BirdTypeId)
                    .HasConstraintName("FK_Product_BirdTypeCategory");
            });

            modelBuilder.Entity<ProductEquipment>(entity =>
            {
                entity.ToTable("ProductEquipment");

                entity.Property(e => e.ProductEquipmentId)
                    .HasMaxLength(200)
                    .HasColumnName("ProductEquipmentID");

                entity.Property(e => e.EquipmentId)
                    .HasMaxLength(200)
                    .HasColumnName("EquipmentID");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ProductID");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.ProductEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK__ProductEq__Equip__4AB81AF0");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductEquipments)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductEq__Produ__49C3F6B7");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Review_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Username, "UQ__User__536C85E4C7AD2A74")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BannedTime).HasColumnType("datetime");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Token)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleID__5070F446");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.VoucherId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("VoucherID");

                entity.Property(e => e.CouponCode).HasMaxLength(50);

                entity.Property(e => e.Discount)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Vouchers)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductVoucher",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductVoucher_Product"),
                        r => r.HasOne<Voucher>().WithMany().HasForeignKey("VoucherId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductVoucher_Voucher"),
                        j =>
                        {
                            j.HasKey("VoucherId", "ProductId");

                            j.ToTable("ProductVoucher");

                            j.IndexerProperty<string>("VoucherId").HasMaxLength(200).IsUnicode(false).HasColumnName("VoucherID");

                            j.IndexerProperty<string>("ProductId").HasMaxLength(200).IsUnicode(false).HasColumnName("ProductID");
                        });

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Vouchers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserVoucher",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserVoucher_User"),
                        r => r.HasOne<Voucher>().WithMany().HasForeignKey("VoucherId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserVoucher_Voucher"),
                        j =>
                        {
                            j.HasKey("VoucherId", "UserId");

                            j.ToTable("UserVoucher");

                            j.IndexerProperty<string>("VoucherId").HasMaxLength(200).IsUnicode(false).HasColumnName("VoucherID");

                            j.IndexerProperty<string>("UserId").HasMaxLength(100).IsUnicode(false).HasColumnName("UserID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
