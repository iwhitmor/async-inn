﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using async_inn.Data;

namespace async_inn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20211020220533_UpdateAmenitiesTableWithCorrectSpelling")]
    partial class UpdateAmenitiesTableWithCorrectSpelling
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("async_inn.Models.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mini-Bar"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Large Couch"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kitchenette"
                        });
                });

            modelBuilder.Entity("async_inn.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Las Vegas",
                            Country = "USA",
                            Name = "MGM Grand",
                            Phone = "800-111-1111",
                            State = "Nevada",
                            StreetAddress = "1 Las Vegas Blvd"
                        },
                        new
                        {
                            Id = 2,
                            City = "Las Vegas",
                            Country = "USA",
                            Name = "Flamingo",
                            Phone = "800-222-2222",
                            State = "Nevada",
                            StreetAddress = "2 Las Vegas Blvd"
                        },
                        new
                        {
                            Id = 3,
                            City = "Las Vegas",
                            Country = "USA",
                            Name = "Golden Nugget",
                            Phone = "800-333-3333",
                            State = "Nevada",
                            StreetAddress = "3 Las Vegas Blvd"
                        });
                });

            modelBuilder.Entity("async_inn.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Layout = 0,
                            Name = "Luxury Suite"
                        },
                        new
                        {
                            Id = 2,
                            Layout = 1,
                            Name = "Deluxe Suite"
                        },
                        new
                        {
                            Id = 3,
                            Layout = 2,
                            Name = "Penthouse Suite"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
