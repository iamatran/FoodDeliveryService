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
    [Migration("20190811201552_Initial")]
    partial class Initial
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

            modelBuilder.Entity("FoodDeliveryService.Models.Food", b =>
                {
                    b.Property<long>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AddressId");

                    b.Property<string>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("FoodId");

                    b.HasIndex("AddressId");

                    b.ToTable("Foods");
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

            modelBuilder.Entity("FoodDeliveryService.Models.Food", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Address", "Address")
                        .WithMany("Foods")
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("FoodDeliveryService.Models.Rating", b =>
                {
                    b.HasOne("FoodDeliveryService.Models.Food", "Food")
                        .WithMany("Ratings")
                        .HasForeignKey("FoodId");
                });
#pragma warning restore 612, 618
        }
    }
}
