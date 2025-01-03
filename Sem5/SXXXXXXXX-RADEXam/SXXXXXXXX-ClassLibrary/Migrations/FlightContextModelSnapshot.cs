﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SXXXXXXXX_ClassLibrary;

#nullable disable

namespace SXXXXXXXX_ClassLibrary.Migrations
{
    [DbContext(typeof(FlightContext))]
    partial class FlightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Booking", b =>
                {
                    b.Property<int>("PassengerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FlightId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaggageCharge")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TicketCost")
                        .HasColumnType("REAL");

                    b.Property<int>("TicketType")
                        .HasColumnType("INTEGER");

                    b.HasKey("PassengerId", "FlightId");

                    b.HasIndex("FlightId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Booking", b =>
                {
                    b.HasOne("SXXXXXXXX_ClassLibrary.Flight", null)
                        .WithMany("Bookings")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SXXXXXXXX_ClassLibrary.Passenger", null)
                        .WithMany("Bookings")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Flight", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("SXXXXXXXX_ClassLibrary.Passenger", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
