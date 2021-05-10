using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Superjonikai.Model.Entities;

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
            modelBuilder.Seed();
        }
    }
}
