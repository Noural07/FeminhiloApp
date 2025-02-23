﻿// <auto-generated />
using System;
using FemApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FemApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240516100607_asd")]
    partial class asd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FemApi.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_0.jpg?raw=true",
                            Name = "Jackets",
                            Price = 100.0
                        },
                        new
                        {
                            Id = 2,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_1.jpg?raw=true",
                            Name = "Pink Jacket",
                            Price = 90.0
                        },
                        new
                        {
                            Id = 3,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_2.jpg?raw=true",
                            Name = "Blue Bag ",
                            Price = 40.0
                        },
                        new
                        {
                            Id = 4,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_3.jpg?raw=true",
                            Name = "Purple dress",
                            Price = 70.0
                        },
                        new
                        {
                            Id = 5,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_4.jpg?raw=true",
                            Name = "Jackets 2",
                            Price = 150.0
                        },
                        new
                        {
                            Id = 6,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_6.jpg?raw=true",
                            Name = "Blue & White Bag",
                            Price = 45.0
                        },
                        new
                        {
                            Id = 7,
                            Image = "https://github.com/Noural07/Images/blob/main/ImagesFem/IMG_7.jpg?raw=true",
                            Name = "Blue Jacket",
                            Price = 80.0
                        });
                });

            modelBuilder.Entity("FemApi.Models.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("OrderdAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FemApi.Models.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("FemApi.Models.OrderItem", b =>
                {
                    b.HasOne("FemApi.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FemApi.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
