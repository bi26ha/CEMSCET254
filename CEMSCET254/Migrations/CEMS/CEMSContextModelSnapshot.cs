﻿// <auto-generated />
using System;
using CEMSCET254.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CEMSCET254.Migrations.CEMS
{
    [DbContext(typeof(CEMSContext))]
    partial class CEMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ActivityEvent", b =>
                {
                    b.Property<int>("ActivitiesId")
                        .HasColumnType("int");

                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.HasKey("ActivitiesId", "EventsId");

                    b.HasIndex("EventsId");

                    b.ToTable("ActivityEvent");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Registration", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Registrations");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("ActivityEvent", b =>
                {
                    b.HasOne("CEMSCET254.Data.Models.Activity", null)
                        .WithMany()
                        .HasForeignKey("ActivitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEMSCET254.Data.Models.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Event", b =>
                {
                    b.HasOne("CEMSCET254.Data.Models.Venue", null)
                        .WithMany("Events")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Registration", b =>
                {
                    b.HasOne("CEMSCET254.Data.Models.Event", "Event")
                        .WithMany("Registrations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CEMSCET254.Data.Models.Participant", "Participant")
                        .WithMany("Registrations")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Participant");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Event", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Participant", b =>
                {
                    b.Navigation("Registrations");
                });

            modelBuilder.Entity("CEMSCET254.Data.Models.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
