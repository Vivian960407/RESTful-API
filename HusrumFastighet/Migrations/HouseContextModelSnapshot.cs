﻿// <auto-generated />
using System;
using HusrumFastighet.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HusrumFastighet.Migrations
{
    [DbContext(typeof(HouseContext))]
    partial class HouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DoorLocation", b =>
                {
                    b.Property<int>("DoorsID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationID")
                        .HasColumnType("INTEGER");

                    b.HasKey("DoorsID", "LocationID");

                    b.HasIndex("LocationID");

                    b.ToTable("DoorLocation");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Door", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DoorCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Doors");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EventCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note2")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Log", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DoorID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TenantID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("DoorID");

                    b.HasIndex("EventID");

                    b.HasIndex("LocationID");

                    b.HasIndex("TenantID");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Tenant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ApartmentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ApartmentID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("DoorLocation", b =>
                {
                    b.HasOne("HusrumFastighet.Models.Door", null)
                        .WithMany()
                        .HasForeignKey("DoorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HusrumFastighet.Models.Location", null)
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HusrumFastighet.Models.Log", b =>
                {
                    b.HasOne("HusrumFastighet.Models.Door", "Door")
                        .WithMany("Log")
                        .HasForeignKey("DoorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HusrumFastighet.Models.Event", "Event")
                        .WithMany("Log")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HusrumFastighet.Models.Location", "Location")
                        .WithMany("Log")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HusrumFastighet.Models.Tenant", "Tenant")
                        .WithMany("Log")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Door");

                    b.Navigation("Event");

                    b.Navigation("Location");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Tenant", b =>
                {
                    b.HasOne("HusrumFastighet.Models.Location", "Apartment")
                        .WithMany("Tenant")
                        .HasForeignKey("ApartmentID");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Door", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Event", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Location", b =>
                {
                    b.Navigation("Log");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("HusrumFastighet.Models.Tenant", b =>
                {
                    b.Navigation("Log");
                });
#pragma warning restore 612, 618
        }
    }
}
