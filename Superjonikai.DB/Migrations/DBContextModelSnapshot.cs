// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Superjonikai.DB;

namespace Superjonikai.DB.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Superjonikai.Model.Entities.Bouquet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Image_path")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Bouquets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Paster pink, white",
                            Image_path = "https://i.pinimg.com/564x/45/5f/82/455f828caa233226cee118db368c1150.jpg",
                            Name = "Peony please",
                            Price = 48.0
                        },
                        new
                        {
                            Id = 2,
                            Color = "Purple, pink",
                            Image_path = "https://i.pinimg.com/564x/39/1a/e2/391ae2faa2451615d0edbaa5a6a99eb6.jpg",
                            Name = "Ramos de flores",
                            Price = 43.0
                        },
                        new
                        {
                            Id = 3,
                            Color = "White, brown",
                            Image_path = "https://i.pinimg.com/564x/b1/f6/ab/b1f6abaa27472a78c4a460fa16a5ce1a.jpg",
                            Name = "Dried cotton",
                            Price = 38.0
                        },
                        new
                        {
                            Id = 4,
                            Color = "Pastel orange, yellow",
                            Image_path = "https://i.pinimg.com/564x/47/a2/98/47a298931d888efe24b220770ba9f793.jpg",
                            Name = "Early spring",
                            Price = 40.0
                        },
                        new
                        {
                            Id = 5,
                            Color = "Light brown, baby pink",
                            Image_path = "https://i.pinimg.com/564x/96/6d/81/966d81ea338beeb0db1da246d6e80194.jpg",
                            Name = "Earthy palette",
                            Price = 42.0
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.BouquetOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BouquetId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasColumnType("longtext");

                    b.HasKey("OrderId", "BouquetId");

                    b.HasIndex("BouquetId");

                    b.ToTable("BouquetOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            BouquetId = 2,
                            Size = "medium"
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Flower", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Image_path")
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Flowers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "pink, white",
                            Image_path = "https://i.pinimg.com/564x/a7/b8/5f/a7b85f63378f0d3fa6c6e5b8c7aad8c5.jpg",
                            Name = "Tulips",
                            Price = 1.8
                        },
                        new
                        {
                            Id = 2,
                            Color = "yellow",
                            Image_path = "https://i.pinimg.com/564x/1d/c6/09/1dc609deb67c38a9befd92b2096b522d.jpg",
                            Name = "Roses",
                            Price = 2.0
                        },
                        new
                        {
                            Id = 3,
                            Color = "white",
                            Image_path = "https://i.pinimg.com/564x/94/33/cd/9433cdf12d481789805feae9c411aecb.jpg",
                            Name = "Lilies",
                            Price = 3.5
                        },
                        new
                        {
                            Id = 4,
                            Color = "yellow",
                            Image_path = "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg",
                            Name = "Sunflower",
                            Price = 4.5
                        },
                        new
                        {
                            Id = 5,
                            Color = "pink",
                            Image_path = "https://i.pinimg.com/564x/68/e4/a6/68e4a652bcc02790770af653291f0b60.jpg",
                            Name = "Peony",
                            Price = 3.5
                        },
                        new
                        {
                            Id = 6,
                            Color = "multi",
                            Image_path = "https://i.pinimg.com/564x/14/c2/63/14c263f41a10ec9ac59bb6a025a38169.jpg",
                            Name = "Foxglove",
                            Price = 7.7999999999999998
                        },
                        new
                        {
                            Id = 7,
                            Color = "multi",
                            Image_path = "https://i.pinimg.com/564x/1f/85/3c/1f853cec192d3146e460279aebada93d.jpg",
                            Name = "Russels",
                            Price = 10.199999999999999
                        },
                        new
                        {
                            Id = 8,
                            Color = "purple",
                            Image_path = "https://i.pinimg.com/564x/49/80/99/498099543e6263cab8f0122002e4acf2.jpg",
                            Name = "Levander",
                            Price = 5.5999999999999996
                        },
                        new
                        {
                            Id = 9,
                            Color = "multi",
                            Image_path = "https://www.haifa-group.com/sites/default/files/crop/Sunflower%20isolated.jpg",
                            Name = "Bunny tails",
                            Price = 1.2
                        },
                        new
                        {
                            Id = 10,
                            Color = "white",
                            Image_path = "https://i.pinimg.com/564x/08/53/f8/0853f8c46e7d7e0e868aab63346ddec9.jpg",
                            Name = "Camomile",
                            Price = 1.5
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.FlowerOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "FlowerId");

                    b.HasIndex("FlowerId");

                    b.ToTable("FlowerOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            FlowerId = 2,
                            Quantity = 6
                        },
                        new
                        {
                            OrderId = 5,
                            FlowerId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderId = 5,
                            FlowerId = 1,
                            Quantity = 3
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.GiftCard.GiftCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("GiftCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Message = "Happy birthday",
                            Price = 3.3999999999999999,
                            Type = "BirthDay"
                        },
                        new
                        {
                            Id = 2,
                            Message = "For my beautiful women",
                            Price = 5.0999999999999996,
                            Type = "WomensDay"
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Logins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "kazkoks",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientName = "Tom Jenkins",
                            DeliveryDate = new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 2,
                            ClientName = "Lalaila Smith",
                            DeliveryDate = new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Paid"
                        },
                        new
                        {
                            Id = 3,
                            ClientName = "Thomas Miller",
                            DeliveryDate = new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Processing"
                        },
                        new
                        {
                            Id = 4,
                            ClientName = "John Brown",
                            DeliveryDate = new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Completed"
                        },
                        new
                        {
                            Id = 5,
                            ClientName = "TitasGrigaitis",
                            DeliveryDate = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "AwaitingPayment"
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Token")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "gg",
                            FirstName = "a",
                            LastName = "b",
                            PhoneNumber = "864444444",
                            Token = "2"
                        },
                        new
                        {
                            Id = 2,
                            Email = "titasgg@gmail.com",
                            FirstName = "Titas",
                            LastName = "Grigaitis",
                            PhoneNumber = "8633434434",
                            Token = "1"
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.BouquetOrder", b =>
                {
                    b.HasOne("Superjonikai.Model.Entities.Bouquet", "Bouquet")
                        .WithMany("Orders")
                        .HasForeignKey("BouquetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superjonikai.Model.Entities.Order.Order", "Order")
                        .WithMany("BouquetsList")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bouquet");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.FlowerOrder", b =>
                {
                    b.HasOne("Superjonikai.Model.Entities.Flower", "Flower")
                        .WithMany("Orders")
                        .HasForeignKey("FlowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Superjonikai.Model.Entities.Order.Order", "Order")
                        .WithMany("FlowersList")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flower");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Bouquet", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Flower", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.Order.Order", b =>
                {
                    b.Navigation("BouquetsList");

                    b.Navigation("FlowersList");
                });
#pragma warning restore 612, 618
        }
    }
}
