﻿// <auto-generated />
using System;
using AspNetMvc.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetMvc.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20231115033603_SeedingProducts")]
    partial class SeedingProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetMvc.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Desktop PC"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tablet"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Console"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Watch"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Photo/Video"
                        },
                        new
                        {
                            Id = 7,
                            Name = "TV/Monitor"
                        });
                });

            modelBuilder.Entity("AspNetMvc.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Sales")
                        .HasColumnType("int");

                    b.Property<double>("SalesPerDay")
                        .HasColumnType("float");

                    b.Property<double>("SalesPerMonth")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7878),
                            Name = "Apple iMac 27\"\"",
                            Price = 799.88m,
                            Rating = 5f,
                            Revenue = 3200000m,
                            Sales = 1600000,
                            SalesPerDay = 1.47,
                            SalesPerMonth = 0.46999999999999997,
                            Stock = 95
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7908),
                            Name = "Apple iMac 20\"\"",
                            Price = 799.88m,
                            Rating = 5f,
                            Revenue = 785000m,
                            Sales = 6000000,
                            SalesPerDay = 1.1499999999999999,
                            SalesPerMonth = 0.32000000000000001,
                            Stock = 108
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-iphone-14.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7913),
                            Name = "Apple iPhone 14",
                            Price = 593.00m,
                            Rating = 4f,
                            Revenue = 3200000m,
                            Sales = 1200000,
                            SalesPerDay = 1.0,
                            SalesPerMonth = 0.94999999999999996,
                            Stock = 24
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-ipad-air.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7919),
                            Name = "Apple iPad Air",
                            Price = 559.00m,
                            Rating = 4f,
                            Revenue = 425000m,
                            Sales = 298000,
                            SalesPerDay = 0.46999999999999997,
                            SalesPerMonth = 1.0,
                            Stock = 287
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-s.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7926),
                            Name = "Xbox Series S",
                            Price = 274.99m,
                            Rating = 5f,
                            Revenue = 345000m,
                            Sales = 99,
                            SalesPerDay = 1.6100000000000001,
                            SalesPerMonth = 0.29999999999999999,
                            Stock = 450
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/playstation-5.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7934),
                            Name = "PlayStation 5",
                            Price = 479.00m,
                            Rating = 4f,
                            Revenue = 4200000m,
                            Sales = 2100000,
                            SalesPerDay = 1.4099999999999999,
                            SalesPerMonth = 0.11,
                            Stock = 2345
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 4,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-x.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7938),
                            Name = "Xbox Series X",
                            Price = 489.99m,
                            Rating = 5f,
                            Revenue = 2270000m,
                            Sales = 989000,
                            SalesPerDay = 7.0899999999999999,
                            SalesPerMonth = 3.3199999999999998,
                            Stock = 235
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 5,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-watch-se.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7945),
                            Name = "Apple Watch SE",
                            Price = 201.48m,
                            Rating = 5f,
                            Revenue = 45000m,
                            Sales = 102,
                            SalesPerDay = 4.96,
                            SalesPerMonth = 0.73999999999999999,
                            Stock = 433
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 6,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/nikon-d850.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7956),
                            Name = "NIKON D850",
                            Price = 2496.95m,
                            Rating = 3f,
                            Revenue = 1520000m,
                            Sales = 1200000,
                            SalesPerDay = 0.20000000000000001,
                            SalesPerMonth = 0.73999999999999999,
                            Stock = 351
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 7,
                            Image = "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/benq-ex2710q.png",
                            LastUpdate = new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7960),
                            Name = "Monitor BENQ EX2710Q",
                            Price = 349.99m,
                            Rating = 4f,
                            Revenue = 1200000m,
                            Sales = 211000,
                            SalesPerDay = 4.1200000000000001,
                            SalesPerMonth = 0.29999999999999999,
                            Stock = 1242
                        });
                });

            modelBuilder.Entity("AspNetMvc.Entities.Product", b =>
                {
                    b.HasOne("AspNetMvc.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AspNetMvc.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}