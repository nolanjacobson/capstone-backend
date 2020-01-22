﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using capstone_backend.Models;

namespace capstonebackend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200116133822_NewRecruiterModelUpdate")]
    partial class NewRecruiterModelUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("capstone_backend.Models.Nurse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("NurseEmail")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("RecruiterEmail")
                        .HasColumnType("text");

                    b.Property<string>("SignatureCanvas")
                        .HasColumnType("text");

                    b.Property<string>("TestDataPdf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Nurse");
                });

            modelBuilder.Entity("capstone_backend.Models.Recruiters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("RecruiterEmail")
                        .HasColumnType("text");

                    b.Property<string>("RecruiterName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recruiter");
                });
#pragma warning restore 612, 618
        }
    }
}