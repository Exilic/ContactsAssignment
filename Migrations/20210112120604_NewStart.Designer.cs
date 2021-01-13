﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mvc_week4849.Models.Database;

namespace mvc_week4849.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20210112120604_NewStart")]
    partial class NewStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mvc_week4849.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CitiesList");
                });

            modelBuilder.Entity("mvc_week4849.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CountriesList");
                });

            modelBuilder.Entity("mvc_week4849.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .HasColumnType("text");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("LanguagesList");
                });

            modelBuilder.Entity("mvc_week4849.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("PersonName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PersonList");
                });

            modelBuilder.Entity("mvc_week4849.Models.City", b =>
                {
                    b.HasOne("mvc_week4849.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("mvc_week4849.Models.Language", b =>
                {
                    b.HasOne("mvc_week4849.Models.Person", null)
                        .WithMany("Languages")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("mvc_week4849.Models.Person", b =>
                {
                    b.HasOne("mvc_week4849.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId");
                });
#pragma warning restore 612, 618
        }
    }
}
