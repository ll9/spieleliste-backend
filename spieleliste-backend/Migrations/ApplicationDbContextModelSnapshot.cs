﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using spieleliste_backend.Data;

namespace spieleliste_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("spieleliste_backend.Models.ListenEintrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SpielId");

                    b.HasKey("Id");

                    b.HasIndex("SpielId");

                    b.ToTable("ListenEintraege");
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

            modelBuilder.Entity("spieleliste_backend.Models.UserEintrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ListenEintragId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ListenEintragId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEintraege");
                });

            modelBuilder.Entity("spieleliste_backend.Models.UserEintrag", b =>
                {
                    b.HasOne("spieleliste_backend.Models.ListenEintrag", "ListenEintrag")
                        .WithMany()
                        .HasForeignKey("ListenEintragId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("spieleliste_backend.Models.User", "User")
                        .WithMany("UserEintraege")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
