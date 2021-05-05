using Microsoft.EntityFrameworkCore;
using Superjonikai.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Superjonikai.DB
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bouquet>().HasData(
                new Bouquet
                {
                    Id = 0,
                    Name = "Simply gorgeous bouquet",
                    Price = 60.30
                },
                new Bouquet
                {
                    Id = 1,
                    Name = "Summer flowers bouquet",
                    Price = 40.3
                },
                new Bouquet
                {
                    Id = 2,
                    Name = "Mixed flowers",
                    Price = 16.4
                },
                new Bouquet
                {
                    Id = 3,
                    Name = "Roses box",
                    Price = 12
                },
                new Bouquet
                {
                    Id = 4,
                    Name = "Bright flower bouquet",
                    Price = 10
                }
                );
            modelBuilder.Entity<Flower>().HasData(
                new Flower
                {
                    Id = 0,
                    Name = "Tulips",
                    Price = 0.7
                },
                new Flower
                {
                    Id = 0,
                    Name = "Roses",
                    Price = 4
                },
                new Flower
                {
                    Id = 0,
                    Name = "Lilies",
                    Price = 3.5
                },
                new Flower
                {
                    Id = 0,
                    Name = "Sunflower",
                    Price = 7.5
                }
            );
        }
    }
}