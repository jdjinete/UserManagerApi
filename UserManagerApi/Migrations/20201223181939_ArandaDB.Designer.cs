﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagerApi.Models;

namespace UserManagerApi.Migrations
{
    [DbContext(typeof(ArandaContext))]
    [Migration("20201223181939_ArandaDB")]
    partial class ArandaDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("UserManagerApi.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Age")
                        .HasColumnType("numeric(3,0)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("binary(64)");

                    b.Property<decimal>("Phone")
                        .HasColumnType("numeric(18,0)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
