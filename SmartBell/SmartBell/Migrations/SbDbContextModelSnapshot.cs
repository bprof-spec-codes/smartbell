﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SmartBell.Migrations
{
    [DbContext(typeof(SbDbContext))]
    partial class SbDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SequenceID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BellRingId");

                    b.ToTable("OutputPaths");
                });

            modelBuilder.Entity("Models.Template", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Templates");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Tízperces csengetési rend"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Tizenöt perces csengetési rend"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Rövidített órák"
                        });
                });

            modelBuilder.Entity("Models.TemplateElement", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BellRingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("time");

                    b.Property<int>("IntervalSeconds")
                        .HasColumnType("int");

                    b.Property<string>("TemplateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateElements");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            BellRingTime = new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "2",
                            BellRingTime = new DateTime(1, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "3",
                            BellRingTime = new DateTime(1, 1, 1, 8, 55, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "4",
                            BellRingTime = new DateTime(1, 1, 1, 9, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "5",
                            BellRingTime = new DateTime(1, 1, 1, 9, 55, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "6",
                            BellRingTime = new DateTime(1, 1, 1, 10, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "7",
                            BellRingTime = new DateTime(1, 1, 1, 10, 50, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "8",
                            BellRingTime = new DateTime(1, 1, 1, 11, 35, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "9",
                            BellRingTime = new DateTime(1, 1, 1, 11, 55, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "10",
                            BellRingTime = new DateTime(1, 1, 1, 12, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "11",
                            BellRingTime = new DateTime(1, 1, 1, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "12",
                            BellRingTime = new DateTime(1, 1, 1, 13, 35, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "13",
                            BellRingTime = new DateTime(1, 1, 1, 13, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "14",
                            BellRingTime = new DateTime(1, 1, 1, 14, 25, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "15",
                            BellRingTime = new DateTime(1, 1, 1, 14, 35, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "16",
                            BellRingTime = new DateTime(1, 1, 1, 15, 20, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "17",
                            BellRingTime = new DateTime(1, 1, 1, 15, 25, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 0
                        },
                        new
                        {
                            Id = "18",
                            BellRingTime = new DateTime(1, 1, 1, 16, 10, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "1",
                            Type = 1
                        },
                        new
                        {
                            Id = "19",
                            BellRingTime = new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "20",
                            BellRingTime = new DateTime(1, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "21",
                            BellRingTime = new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "22",
                            BellRingTime = new DateTime(1, 1, 1, 9, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "23",
                            BellRingTime = new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "24",
                            BellRingTime = new DateTime(1, 1, 1, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "25",
                            BellRingTime = new DateTime(1, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "26",
                            BellRingTime = new DateTime(1, 1, 1, 11, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "27",
                            BellRingTime = new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "28",
                            BellRingTime = new DateTime(1, 1, 1, 12, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "29",
                            BellRingTime = new DateTime(1, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "30",
                            BellRingTime = new DateTime(1, 1, 1, 13, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "31",
                            BellRingTime = new DateTime(1, 1, 1, 13, 55, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "32",
                            BellRingTime = new DateTime(1, 1, 1, 14, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "33",
                            BellRingTime = new DateTime(1, 1, 1, 14, 50, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "34",
                            BellRingTime = new DateTime(1, 1, 1, 15, 35, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "35",
                            BellRingTime = new DateTime(1, 1, 1, 15, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 0
                        },
                        new
                        {
                            Id = "36",
                            BellRingTime = new DateTime(1, 1, 1, 16, 25, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "2",
                            Type = 1
                        },
                        new
                        {
                            Id = "37",
                            BellRingTime = new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "38",
                            BellRingTime = new DateTime(1, 1, 1, 8, 35, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        },
                        new
                        {
                            Id = "39",
                            BellRingTime = new DateTime(1, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "40",
                            BellRingTime = new DateTime(1, 1, 1, 9, 20, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        },
                        new
                        {
                            Id = "41",
                            BellRingTime = new DateTime(1, 1, 1, 9, 25, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "42",
                            BellRingTime = new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        },
                        new
                        {
                            Id = "43",
                            BellRingTime = new DateTime(1, 1, 1, 10, 5, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "44",
                            BellRingTime = new DateTime(1, 1, 1, 10, 40, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        },
                        new
                        {
                            Id = "45",
                            BellRingTime = new DateTime(1, 1, 1, 10, 45, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "46",
                            BellRingTime = new DateTime(1, 1, 1, 11, 20, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        },
                        new
                        {
                            Id = "47",
                            BellRingTime = new DateTime(1, 1, 1, 11, 25, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 0
                        },
                        new
                        {
                            Id = "48",
                            BellRingTime = new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            FilePath = "default.mp3",
                            Interval = new TimeSpan(0, 0, 0, 10, 0),
                            IntervalSeconds = 10,
                            TemplateId = "3",
                            Type = 1
                        });
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
