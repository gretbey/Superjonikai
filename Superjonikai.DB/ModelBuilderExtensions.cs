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
                    Id = 1,
                    Name = "Simply gorgeous bouquet",
                    Price = 60.30,
                    Color = "yellow"
                },
                new Bouquet
                {
                    Id = 2,
                    Name = "Summer flowers bouquet",
                    Price = 40.3,
                    Color = "yellow"
                },
                new Bouquet
                {
                    Id = 3,
                    Name = "Mixed flowers",
                    Price = 16.4,
                    Color = "yellow"
                },
                new Bouquet
                {
                    Id = 4,
                    Name = "Roses box",
                    Price = 12,
                    Color = "yellow"
                },
                new Bouquet
                {
                    Id = 5,
                    Name = "Bright flower bouquet",
                    Price = 10,
                    Color = "yellow"
                }
                );
            modelBuilder.Entity<Flower>().HasData(
                new Flower
                {
                    Id = 1,
                    Name = "Tulips",
                    Price = 0.7,
                    Color = "yellow"
                },
                new Flower
                {
                    Id = 2,
                    Name = "Roses",
                    Price = 4,
                    Color = "yellow"
                },
                new Flower
                {
                    Id = 3,
                    Name = "Lilies",
                    Price = 3.5,
                    Color = "yellow"
                },
                new Flower
                {
                    Id = 4,
                    Name = "Sunflower",
                    Price = 7.5,
                    Color = "yellow"
                }
            );
            modelBuilder.Entity<Login>().HasData(
               new Login
               {
                   Id = 1,
                   Email = "kazkoks",
                   Password = "1234"
               }
            ); ;
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 1,
                  Email = "gg",
                  FirstName = "a",
                  LastName = "b"
              }
           );
        }
    }
}