﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    [DbContext(typeof(PushNotificationsDbContext))]
    partial class PushNotificationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TopCase.OlivaTaxi.PushNotifications.Database.Models.DriverToken", b =>
                {
                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Platform")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Uid", "Timestamp");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("DriverTokens");
                });

            modelBuilder.Entity("TopCase.OlivaTaxi.PushNotifications.Database.Models.PassengerToken", b =>
                {
                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Platform")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Uid", "Timestamp");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("PassengerTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
