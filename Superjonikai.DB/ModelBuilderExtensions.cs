using Microsoft.EntityFrameworkCore;
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
                    Name = "Peony please",
                    Price = 48,
                    Color = "Paster pink, white",
                    Image_path = "https://i.pinimg.com/564x/45/5f/82/455f828caa233226cee118db368c1150.jpg"
                },
                new Bouquet
                {
                    Id = 2,
                    Name = "Ramos de flores",
                    Price = 43,
                    Color = "Purple, pink",
                    Image_path = "https://i.pinimg.com/564x/39/1a/e2/391ae2faa2451615d0edbaa5a6a99eb6.jpg"
                },
                new Bouquet
                {
                    Id = 3,
                    Name = "Dried cotton",
                    Price = 38,
                    Color = "White, brown",
                    Image_path = "https://i.pinimg.com/564x/b1/f6/ab/b1f6abaa27472a78c4a460fa16a5ce1a.jpg"
                },
                new Bouquet
                {
                    Id = 4,
                    Name = "Early spring",
                    Price = 40,
                    Color = "Pastel orange, yellow",
                    Image_path = "https://i.pinimg.com/564x/47/a2/98/47a298931d888efe24b220770ba9f793.jpg"
                },
                new Bouquet
                {
                    Id = 5,
                    Name = "Earthy palette",
                    Price = 42,
                    Color = "Light brown, baby pink",
                    Image_path = "https://i.pinimg.com/564x/96/6d/81/966d81ea338beeb0db1da246d6e80194.jpg"
                }


                );
            modelBuilder.Entity<Flower>().HasData(
                new Flower
                {
                    Id = 1,
                    Name = "Tulips",
                    Price = 1.8,
                    Color = "pink, white",
                    Image_path = "https://i.pinimg.com/564x/a7/b8/5f/a7b85f63378f0d3fa6c6e5b8c7aad8c5.jpg"                
                },
                new Flower
                {
                    Id = 2,
                    Name = "Roses",
                    Price = 2,
                    Color = "yellow",
                    Image_path = "https://i.pinimg.com/564x/1d/c6/09/1dc609deb67c38a9befd92b2096b522d.jpg"
                },
                new Flower
                {
                    Id = 3,
                    Name = "Lilies",
                    Price = 3.5,
                    Color = "white",
                    Image_path = "https://i.pinimg.com/564x/94/33/cd/9433cdf12d481789805feae9c411aecb.jpg"
                },
                new Flower
                {
                    Id = 4,
                    Name = "Sunflower",
                    Price = 4.5,
                    Color = "yellow",
                    Image_path = "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg"
                },
                new Flower
                {
                    Id = 5,
                    Name = "Peony",
                    Price = 3.5,
                    Color = "pink",
                    Image_path = "https://i.pinimg.com/564x/68/e4/a6/68e4a652bcc02790770af653291f0b60.jpg"
                },
                new Flower
                {
                    Id = 6,
                    Name = "Foxglove",
                    Price = 7.8,
                    Color = "multi",
                    Image_path = "https://i.pinimg.com/564x/14/c2/63/14c263f41a10ec9ac59bb6a025a38169.jpg"
                },
                new Flower
                {
                    Id = 7,
                    Name = "Russels",
                    Price = 10.2,
                    Color = "multi",
                    Image_path = "https://i.pinimg.com/564x/1f/85/3c/1f853cec192d3146e460279aebada93d.jpg"
                },
                new Flower
                {
                    Id = 8,
                    Name = "Levander",
                    Price = 5.6,
                    Color = "purple",
                    Image_path = "https://i.pinimg.com/564x/49/80/99/498099543e6263cab8f0122002e4acf2.jpg"
                },
                new Flower
                {
                    Id = 9,
                    Name = "Bunny tails",
                    Price = 1.2,
                    Color = "multi",
                    Image_path = "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg"
                },
                new Flower
                {
                    Id = 10,
                    Name = "Camomile",
                    Price = 1.5,
                    Color = "white",
                    Image_path = "https://i.pinimg.com/564x/08/53/f8/0853f8c46e7d7e0e868aab63346ddec9.jpg"
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
                  LastName = "b",
                  PhoneNumber = "864444444",
                  Token = "2"
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
                  LastName = "Grigaitis",
                  PhoneNumber = "8633434434",
                  Token = "1"
              }
           );

        }
    }
}