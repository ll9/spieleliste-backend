﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spieleliste_backend.Data;

namespace spieleliste_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190920203214_UserEntryIndex")]
    partial class UserEntryIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("spieleliste_backend.Models.ListEntry", b =>
                {
                    b.Property<int>("IgdbId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("IgdbId");

                    b.ToTable("ListEntries");
                });

            modelBuilder.Entity("spieleliste_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("spieleliste_backend.Models.UserEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Index");

                    b.Property<int>("ListEntryId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ListEntryId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEntries");
                });

            modelBuilder.Entity("spieleliste_backend.Models.UserEntry", b =>
                {
                    b.HasOne("spieleliste_backend.Models.ListEntry", "ListEntry")
                        .WithMany()
                        .HasForeignKey("ListEntryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("spieleliste_backend.Models.User", "User")
                        .WithMany("UserEntries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}