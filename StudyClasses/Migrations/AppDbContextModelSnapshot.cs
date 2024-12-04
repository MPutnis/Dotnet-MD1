﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyClasses;

#nullable disable

namespace StudyClasses.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudyClasses.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ContractDate")
                        .HasColumnType("date");

                    b.Property<string>("ContractDateSerialized")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonGender")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ContractDate = new DateOnly(2021, 10, 10),
                            ContractDateSerialized = "2021-10-10",
                            Name = "Albert",
                            PersonGender = 1,
                            Surname = "Loop"
                        },
                        new
                        {
                            Id = -2,
                            ContractDate = new DateOnly(2015, 8, 8),
                            ContractDateSerialized = "2015-08-08",
                            Name = "Linda",
                            PersonGender = 0,
                            Surname = "Palinda"
                        },
                        new
                        {
                            Id = -3,
                            ContractDate = new DateOnly(2019, 5, 6),
                            ContractDateSerialized = "2019-05-06",
                            Name = "John",
                            PersonGender = 1,
                            Surname = "Doe"
                        },
                        new
                        {
                            Id = -4,
                            ContractDate = new DateOnly(2023, 3, 4),
                            ContractDateSerialized = "2023-03-04",
                            Name = "Jane",
                            PersonGender = 2,
                            Surname = "Done"
                        },
                        new
                        {
                            Id = -5,
                            ContractDate = new DateOnly(2020, 2, 1),
                            ContractDateSerialized = "2020-02-01",
                            Name = "Hanter",
                            PersonGender = 1,
                            Surname = "Banter"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
