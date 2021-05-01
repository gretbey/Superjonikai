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
        public DbSet<Bouquet> Bouquets { set; get; }
        public DbSet<Flower> Flowers { set; get; }
        public DbSet<Login> Logins { set; get; }
        public DbSet<User> Users { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
