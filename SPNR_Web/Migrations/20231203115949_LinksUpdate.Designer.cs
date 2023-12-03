﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SPNR_Web.DataAccess;

#nullable disable

namespace SPNR_Web.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231203115949_LinksUpdate")]
    partial class LinksUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Header", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("Headers");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Link", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("HeaderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HeaderId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.SubEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("SubEvents");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.TextBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uuid");

                    b.Property<string>("Footer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MainText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Header", b =>
                {
                    b.HasOne("SPNR_Web.Models.DataBase.Event", "Event")
                        .WithOne("Header")
                        .HasForeignKey("SPNR_Web.Models.DataBase.Header", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Link", b =>
                {
                    b.HasOne("SPNR_Web.Models.DataBase.Header", "Header")
                        .WithMany("Links")
                        .HasForeignKey("HeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Header");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.SubEvent", b =>
                {
                    b.HasOne("SPNR_Web.Models.DataBase.Event", "Event")
                        .WithMany("SubEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.TextBlock", b =>
                {
                    b.HasOne("SPNR_Web.Models.DataBase.Event", "Event")
                        .WithMany("Blocks")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Event", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Header")
                        .IsRequired();

                    b.Navigation("SubEvents");
                });

            modelBuilder.Entity("SPNR_Web.Models.DataBase.Header", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
