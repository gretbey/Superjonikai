﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Superjonikai.DB;

namespace Superjonikai.DB.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210521122413_seed-dt2")]
    partial class seeddt2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Color = "yellow",
                            Name = "Simply gorgeous bouquet",
                            Price = 60.299999999999997
                        },
                        new
                        {
                            Id = 2,
                            Color = "yellow",
                            Name = "Summer flowers bouquet",
                            Price = 40.299999999999997
                        },
                        new
                        {
                            Id = 3,
                            Color = "yellow",
                            Name = "Mixed flowers",
                            Price = 16.399999999999999
                        },
                        new
                        {
                            Id = 4,
                            Color = "yellow",
                            Name = "Roses box",
                            Price = 12.0
                        },
                        new
                        {
                            Id = 5,
                            Color = "yellow",
                            Name = "Bright flower bouquet",
                            Price = 10.0
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.BouquetOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BouquetId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "BouquetId");

                    b.HasIndex("BouquetId");

                    b.ToTable("BouquetOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            BouquetId = 2
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
                            Color = "yellow",
                            Name = "Tulips",
                            Price = 0.69999999999999996
                        },
                        new
                        {
                            Id = 2,
                            Color = "yellow",
                            Name = "Roses",
                            Price = 4.0
                        },
                        new
                        {
                            Id = 3,
                            Color = "yellow",
                            Name = "Lilies",
                            Price = 3.5
                        },
                        new
                        {
                            Id = 4,
                            Color = "yellow",
                            Name = "Sunflower",
                            Price = 7.5
                        });
                });

            modelBuilder.Entity("Superjonikai.Model.Entities.FlowerOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("FlowerId")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "FlowerId");

                    b.HasIndex("FlowerId");

                    b.ToTable("FlowerOrders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            FlowerId = 2
                        },
                        new
                        {
                            OrderId = 5,
                            FlowerId = 2
                        },
                        new
                        {
                            OrderId = 5,
                            FlowerId = 1
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
                            LastName = "b"
                        },
                        new
                        {
                            Id = 2,
                            Email = "titasgg@gmail.com",
                            FirstName = "Titas",
                            LastName = "Grigaitis"
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
