﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartBell.Migrations
{
    [DbContext(typeof(SbDbContext))]
    [Migration("20210324132822_OutputPathsmig")]
    partial class OutputPathsmig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.BellRing", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BellRingTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.Property<int>("IntervalSeconds")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BellRings");
                });

            modelBuilder.Entity("Models.Holiday", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Models.OutputPath", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BellRingId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FilePath")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BellRingId");

                    b.ToTable("OutputPaths");
                });

            modelBuilder.Entity("Models.Template", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("Models.TemplateElement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BellRingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.Property<string>("TemplateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateElements");
                });

            modelBuilder.Entity("Models.OutputPath", b =>
                {
                    b.HasOne("Models.BellRing", "ParentBellRing")
                        .WithMany("OutputPaths")
                        .HasForeignKey("BellRingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentBellRing");
                });

            modelBuilder.Entity("Models.TemplateElement", b =>
                {
                    b.HasOne("Models.Template", "ParentTemplate")
                        .WithMany("TemplateElements")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentTemplate");
                });

            modelBuilder.Entity("Models.BellRing", b =>
                {
                    b.Navigation("OutputPaths");
                });

            modelBuilder.Entity("Models.Template", b =>
                {
                    b.Navigation("TemplateElements");
                });
#pragma warning restore 612, 618
        }
    }
}
