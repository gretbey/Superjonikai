using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Entities.GiftCard;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Superjonikai.Model.Entities.Order;

namespace Superjonikai.DB
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        public DbSet<Bouquet> Bouquets { set; internal  get; }
        public DbSet<Flower> Flowers { set; internal get; }
        public DbSet<Login> Logins { set; internal get; }
        public DbSet<User> Users { set; internal get; }
        public DbSet<Order> Orders { set; internal get; }
        public DbSet<GiftCard> GiftCards { set; internal get; }
        public DbSet<FlowerOrder> FlowerOrders { set; internal get; }
        public DbSet<BouquetOrder> BouquetOrders { set; internal get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Email).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.FirstName).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.LastName).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.PhoneNumber).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Token).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
            });
            modelBuilder.Entity<Login>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Email).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Password).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
            });
            modelBuilder.Entity<Flower>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Color).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Name).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Price);
                u.Property(e => e.Image_path).HasColumnType("varchar")
                .HasMaxLength(256).IsUnicode(false);
            });
            modelBuilder.Entity<Bouquet>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Color).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Name).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Price);

            });
            modelBuilder.Entity<GiftCard>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.Type)
                .HasConversion(new EnumToStringConverter<GiftCardType>())
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Message).HasColumnType("varchar")
                .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.Price);
            });
            modelBuilder.Entity<Order>(u =>
            {
                u.HasKey(e => e.Id);
                u.Property(e => e.ClientName).HasColumnType("varchar")
                               .HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.DeliveryDate);
                u.Property(e => e.Status)
                .HasConversion(converter: new EnumToStringConverter<OrderStatus>())
                .HasColumnType("varchar").HasMaxLength(255).IsUnicode(false);
                u.Property(e => e.RowVersion);
                //.HasMaxLength(255).IsUnicode(false);
                //u.HasMany<Flower>(s => s.FlowersList).WithMany(c => c.Orders);
            });
            modelBuilder.Entity<FlowerOrder>()
               .HasKey(t => new { t.OrderId, t.FlowerId });

            modelBuilder.Entity<FlowerOrder>()
                .HasOne(es => es.Order)
                .WithMany(e => e.FlowersList)
                .HasForeignKey(es => es.OrderId);
            modelBuilder.Entity<FlowerOrder>()
                .HasOne(es => es.Flower)
                .WithMany(s => s.Orders)
                .HasForeignKey(es => es.FlowerId);

            modelBuilder.Entity<BouquetOrder>()
               .HasKey(t => new { t.OrderId, t.BouquetId });

            modelBuilder.Entity<BouquetOrder>()
                .HasOne(es => es.Order)
                .WithMany(e => e.BouquetsList)
                .HasForeignKey(es => es.OrderId);
            modelBuilder.Entity<BouquetOrder>()
                .HasOne(es => es.Bouquet)
                .WithMany(s => s.Orders)
                .HasForeignKey(es => es.BouquetId);

            modelBuilder.Seed();
        }
    }
}
