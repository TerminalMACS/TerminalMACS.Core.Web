﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TerminalMACS.Infrastructure.EntityFrameworkCore;

namespace TerminalMACS.Infrastructure.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20200622093030_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TerminalMACS.Domain.Entitys.testA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ModelAs");
                });

            modelBuilder.Entity("TerminalMACS.Domain.Entitys.testB", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ModelAId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("testAId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("testAId");

                    b.ToTable("ModelBs");
                });

            modelBuilder.Entity("TerminalMACS.Domain.Entitys.testB", b =>
                {
                    b.HasOne("TerminalMACS.Domain.Entitys.testA", null)
                        .WithMany("ModelBs")
                        .HasForeignKey("testAId");
                });
#pragma warning restore 612, 618
        }
    }
}
