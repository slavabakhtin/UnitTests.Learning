﻿// <auto-generated />
using System;
using Eiip.PushNotifications.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace TopCase.OlivaTaxi.PushNotifications.Database.Migrations
{
    [DbContext(typeof(PushNotificationsDbContext))]
    [Migration("20200226125302_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TopCase.OlivaTaxi.PushNotifications.Database.Models.FcmToken", b =>
                {
                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FcmToken")
                        .HasColumnType("text");

                    b.HasKey("Uid", "Timestamp");

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("TopCase.OlivaTaxi.PushNotifications.Database.Models.PassengerToken", b =>
                {
                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FcmToken")
                        .HasColumnType("text");

                    b.HasKey("Uid", "Timestamp");

                    b.ToTable("PassengerTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
