﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCM.Students.Data;

namespace SCM.Students.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20200927032243_NullKeysConstraints")]
    partial class NullKeysConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCM.Students.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("RollNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Lahore, Pakistan",
                            Email = "azhar@test.com",
                            IsDeleted = false,
                            Name = "Azhar Riaz",
                            Phone = "+923416311582",
                            RollNo = "RLNO-123"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Lahore, Pakistan",
                            Email = "muzammil@test.com",
                            IsDeleted = false,
                            Name = "Muzammil Ali",
                            Phone = "+923416313452",
                            RollNo = "RLNO-124"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bahawalpur, Pakistan",
                            Email = "awais234@test.com",
                            IsDeleted = false,
                            Name = "Awais Ali",
                            Phone = "+923416313098",
                            RollNo = "RLNO-125"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Qusoor, Pakistan",
                            Email = "sheharyar04@test.com",
                            IsDeleted = false,
                            Name = "Sheharyar Akram",
                            Phone = "+923416378798",
                            RollNo = "RLNO-126"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
