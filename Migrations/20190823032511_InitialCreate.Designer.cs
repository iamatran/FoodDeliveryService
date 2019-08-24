﻿// <auto-generated />
using System;
using FoodDeliveryService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDeliveryService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190823032511_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDeliveryService.Models.Address", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.CartLine", b =>
                {
                    b.Property<long>("CartLineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FoodId");

                    b.Property<long?>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineId");

                    b.HasIndex("OrderId");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Food", b =>
                {
                    b.Property<long>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId");

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("FoodId");

                    b.HasIndex("AddressId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("PaymentId");

                    b.Property<bool>("Shipped");

                    b.HasKey("OrderId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Payment", b =>
                {
                    b.Property<long>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthCode");

                    b.Property<string>("CardExpiry")
                        .IsRequired();

                    b.Property<string>("CardNumber")
                        .IsRequired();

                    b.Property<int>("CardSecurityCode");

                    b.Property<decimal>("Total");

                    b.HasKey("PaymentId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Rating", b =>
                {
                    b.Property<long>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("FoodId");

                    b.Property<int>("Stars");

                    b.HasKey("RatingId");

                    b.HasIndex("FoodId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.CartLine", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Order")
                        .WithMany("Foods")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Food", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Address", "Address")
                        .WithMany("Foods")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Order", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Rating", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Food", "Food")
                        .WithMany("Ratings")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}