﻿// <auto-generated />
using System;
using Ecomm.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecomm.Migrations
{
    [DbContext(typeof(EcommContext))]
    [Migration("20240722184908_tablupd")]
    partial class tablupd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecomm.Models.Awards", b =>
                {
                    b.Property<int>("AwardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AwardId"));

                    b.Property<string>("AwardDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AwardId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("StudentId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("Ecomm.Models.Brand", b =>
                {
                    b.Property<int>("Bid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bid"));

                    b.Property<string>("BName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Bid");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Ecomm.Models.Category", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cid");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ecomm.Models.Competitions", b =>
                {
                    b.Property<int>("CopetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopetitionId"));

                    b.Property<string>("AwardDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CompEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CompStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CopetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("Ecomm.Models.Product", b =>
                {
                    b.Property<int>("Pid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pid"));

                    b.Property<int>("BId")
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<string>("PDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PPrice")
                        .HasColumnType("float");

                    b.HasKey("Pid");

                    b.HasIndex("BId");

                    b.HasIndex("CId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ecomm.Models.Role", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RId"));

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Ecomm.Models.Submissions", b =>
                {
                    b.Property<int>("SubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubId"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Mark")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("StaffRemarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SubId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("StudentId");

                    b.ToTable("submissions");
                });

            modelBuilder.Entity("Ecomm.Models.UpcomingExhibitions", b =>
                {
                    b.Property<int>("UpExbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UpExbId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpExbDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpExbTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("enddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("startdate")
                        .HasColumnType("datetime2");

                    b.HasKey("UpExbId");

                    b.ToTable("upcomingExhibitions");
                });

            modelBuilder.Entity("Ecomm.Models.Users", b =>
                {
                    b.Property<int>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Uid"));

                    b.Property<string>("UEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("URole")
                        .HasColumnType("int");

                    b.HasKey("Uid");

                    b.HasIndex("URole");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<int>("StdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StdId"));

                    b.Property<string>("ImageFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StdAge")
                        .HasColumnType("int");

                    b.Property<DateTime>("StdBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StdContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StdId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Ecomm.Models.Awards", b =>
                {
                    b.HasOne("Ecomm.Models.Competitions", "Competitions")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competitions");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Ecomm.Models.Product", b =>
                {
                    b.HasOne("Ecomm.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecomm.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("category");
                });

            modelBuilder.Entity("Ecomm.Models.Submissions", b =>
                {
                    b.HasOne("Ecomm.Models.Competitions", "Competitions")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competitions");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Ecomm.Models.Users", b =>
                {
                    b.HasOne("Ecomm.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("URole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
