﻿using Microsoft.EntityFrameworkCore;
using Superjonikai.Model.Entities;
using Superjonikai.Model.Entities.GiftCard;
using Superjonikai.Model.Entities.Order;
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
            modelBuilder.Entity<GiftCard>().HasData(
             new GiftCard
             {
                 Id = 1,
                 Type = GiftCardType.BirthDay,
                 Message = "Happy birthday",
                 Price = 3.40
             },
             new GiftCard
             {
                 Id = 2,
                 Type = GiftCardType.WomensDay,
                 Message = "For my beautiful women",
                 Price = 5.1
             }
          );
            modelBuilder.Entity<Order>().HasData(
                 new Order
                 {
                     Id = 1,
                     ClientName = "Tom Jenkins",
                     DeliveryDate = new DateTime(2021, 5, 16),
                     Status = OrderStatus.Completed,
                 },
                 new Order
                 {
                     Id = 2,
                     ClientName = "Lalaila Smith",
                     DeliveryDate = new DateTime(2021, 5, 16),
                     Status = OrderStatus.Paid,
                 },
                 new Order
                 {
                     Id = 3,
                     ClientName = "Thomas Miller",
                     DeliveryDate = new DateTime(2021, 5, 16),
                     Status = OrderStatus.Processing,
                 },
                 new Order
                 {
                     Id = 4,
                     ClientName = "John Brown",
                     DeliveryDate = new DateTime(2021, 5, 16),
                     Status = OrderStatus.Completed,
                 },
                 new Order
                 {
                     Id = 5,
                     ClientName = "TitasGrigaitis",
                     DeliveryDate = new DateTime(2021, 05, 21),
                     Status = OrderStatus.AwaitingPayment
                 }

           );
            modelBuilder.Entity<FlowerOrder>().HasData(
                new FlowerOrder
                {
                    FlowerId = 2,
                    OrderId = 1,
                    Quantity = 6
                }
            );
            modelBuilder.Entity<BouquetOrder>().HasData(
                new BouquetOrder
                {
                    BouquetId = 2,
                    OrderId = 1,
                    Size = "medium"
                }
            );
            modelBuilder.Entity<FlowerOrder>().HasData(
                new FlowerOrder
                {
                    FlowerId = 2,
                    OrderId = 5,
                    Quantity = 3
                }
            );
            modelBuilder.Entity<FlowerOrder>().HasData(
                new FlowerOrder
                {
                    FlowerId = 1,
                    OrderId = 5,
                    Quantity = 3
                }
            );
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 2,
                  Email = "titasgg@gmail.com",
                  FirstName = "Titas",
                  LastName = "Grigaitis"
              }
           );

        }
    }
}