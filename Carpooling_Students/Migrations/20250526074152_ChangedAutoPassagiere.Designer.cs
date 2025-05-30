﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Carpooling_Students.Migrations
{
    [DbContext(typeof(CarpoolContext))]
    [Migration("20250526074152_ChangedAutoPassagiere")]
    partial class ChangedAutoPassagiere
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("Carpooling_Students.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Coins")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("FahrtId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GesamtDistanz")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.HasIndex("FahrtId");

                    b.ToTable("Personen");
                });

            modelBuilder.Entity("Carpooling_Students.Model.Routen", b =>
                {
                    b.Property<int>("RoutenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Distanz")
                        .HasColumnType("REAL");

                    b.Property<string>("StartOrt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Weg")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZielOrt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoutenId");

                    b.ToTable("Routen");
                });

            modelBuilder.Entity("Fahrt", b =>
                {
                    b.Property<int>("FahrtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Abgeschlossen")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDatum")
                        .HasColumnType("TEXT");

                    b.Property<int>("FahrerPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoutenId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sitze")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("TEXT");

                    b.Property<int>("Typ")
                        .HasColumnType("INTEGER");

                    b.HasKey("FahrtId");

                    b.HasIndex("FahrerPersonId");

                    b.HasIndex("RoutenId");

                    b.ToTable("Fahrten");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int?>("ShopId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ItemId");

                    b.HasIndex("ShopId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Carpooling_Students.Model.Person", b =>
                {
                    b.HasOne("Fahrt", null)
                        .WithMany("Passagiere")
                        .HasForeignKey("FahrtId");
                });

            modelBuilder.Entity("Fahrt", b =>
                {
                    b.HasOne("Carpooling_Students.Model.Person", "Fahrer")
                        .WithMany()
                        .HasForeignKey("FahrerPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carpooling_Students.Model.Routen", "Route")
                        .WithMany()
                        .HasForeignKey("RoutenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fahrer");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Item", b =>
                {
                    b.HasOne("Shop", null)
                        .WithMany("Items")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("Fahrt", b =>
                {
                    b.Navigation("Passagiere");
                });

            modelBuilder.Entity("Shop", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
