using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class SbDbContext : DbContext
    {
        public SbDbContext()
        {
            this.Database.EnsureCreated();
        }
        public SbDbContext(DbContextOptions<SbDbContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().UseSqlServer(@"Server=tcp:smartbell.database.windows.net,1433;Initial Catalog=SmartBell;Persist Security Info=False;User ID=sm_admin;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", b => b.MigrationsAssembly("SmartBell"));
            }
        }

        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateElement> TemplateElements { get; set; }
        public DbSet<BellRing> BellRings { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<OutputPath> OutputPaths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Template tenminutetemplate = new Template { Id = "TenminuteTemplate", Name = "Tízperces csengetési rend" };
            Template fifteenminutetemplate = new Template { Id = "FifteenminuteTemplate", Name = "Tizenöt perces csengetési rend" };
            Template shortenedtemplate = new Template { Id = "ShortenedTemplate", Name = "Rövidített órák" };
            modelBuilder.Entity<Template>().HasData(tenminutetemplate,fifteenminutetemplate,shortenedtemplate);

            modelBuilder.Entity<TemplateElement>().HasData(
             
                new { Id = "1", BellRingTime = new DateTime(0, 0, 0, 8, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "2", BellRingTime = new DateTime(0, 0, 0, 8, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "3", BellRingTime = new DateTime(0, 0, 0, 8, 55, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "4", BellRingTime = new DateTime(0, 0, 0, 9, 40, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "5", BellRingTime = new DateTime(0, 0, 0, 9, 55, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "6", BellRingTime = new DateTime(0, 0, 0, 10, 40, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "7", BellRingTime = new DateTime(0, 0, 0, 10, 50, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "8", BellRingTime = new DateTime(0, 0, 0, 11, 35, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "9", BellRingTime = new DateTime(0, 0, 0, 11, 55, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "10", BellRingTime = new DateTime(0, 0, 0, 12, 40, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "11", BellRingTime = new DateTime(0, 0, 0, 12, 50, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "12", BellRingTime = new DateTime(0, 0, 0, 13, 35, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "13", BellRingTime = new DateTime(0, 0, 0, 13, 40, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "14", BellRingTime = new DateTime(0, 0, 0, 14, 25, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "15", BellRingTime = new DateTime(0, 0, 0, 14, 35, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "16", BellRingTime = new DateTime(0, 0, 0, 15, 20, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },

                new { Id = "17", BellRingTime = new DateTime(0, 0, 0, 15, 25, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = tenminutetemplate.Id },
                new { Id = "18", BellRingTime = new DateTime(0, 0, 0, 16, 10, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = tenminutetemplate.Id },



                new { Id = "19", BellRingTime = new DateTime(0, 0, 0, 8, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "20", BellRingTime = new DateTime(0, 0, 0, 8, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "21", BellRingTime = new DateTime(0, 0, 0, 9, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "22", BellRingTime = new DateTime(0, 0, 0, 9, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "23", BellRingTime = new DateTime(0, 0, 0, 10, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "24", BellRingTime = new DateTime(0, 0, 0, 10, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "25", BellRingTime = new DateTime(0, 0, 0, 11, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "26", BellRingTime = new DateTime(0, 0, 0, 11, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "27", BellRingTime = new DateTime(0, 0, 0, 12, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "28", BellRingTime = new DateTime(0, 0, 0, 12, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "29", BellRingTime = new DateTime(0, 0, 0, 13, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "30", BellRingTime = new DateTime(0, 0, 0, 13, 45, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "31", BellRingTime = new DateTime(0, 0, 0, 13, 55, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "32", BellRingTime = new DateTime(0, 0, 0, 14, 40, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "33", BellRingTime = new DateTime(0, 0, 0, 14, 50, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "34", BellRingTime = new DateTime(0, 0, 0, 15, 35, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },

                new { Id = "35", BellRingTime = new DateTime(0, 0, 0, 15, 40, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = fifteenminutetemplate.Id },
                new { Id = "36", BellRingTime = new DateTime(0, 0, 0, 16, 25, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = fifteenminutetemplate.Id },



                new { Id = "37", BellRingTime = new DateTime(0, 0, 0, 8, 0, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "38", BellRingTime = new DateTime(0, 0, 0, 8, 35, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                new { Id = "38", BellRingTime = new DateTime(0, 0, 0, 8, 45, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "39", BellRingTime = new DateTime(0, 0, 0, 9, 20, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                new { Id = "40", BellRingTime = new DateTime(0, 0, 0, 9, 25, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "41", BellRingTime = new DateTime(0, 0, 0, 10, 0, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                new { Id = "42", BellRingTime = new DateTime(0, 0, 0, 10, 5, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "43", BellRingTime = new DateTime(0, 0, 0, 10, 40, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                new { Id = "44", BellRingTime = new DateTime(0, 0, 0, 10, 45, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "45", BellRingTime = new DateTime(0, 0, 0, 11, 20, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                new { Id = "46", BellRingTime = new DateTime(0, 0, 0, 11, 25, 0), IntervalSeconds = 15, Type = BellRingType.Start, TemplateId = shortenedtemplate.Id },
                new { Id = "47", BellRingTime = new DateTime(0, 0, 0, 12, 0, 0), IntervalSeconds = 15, Type = BellRingType.End, TemplateId = shortenedtemplate.Id },

                );




            modelBuilder.Entity<TemplateElement>(entity =>
            {
                entity.
                HasOne(templateElement => templateElement.ParentTemplate)
                .WithMany(template => template.TemplateElements)
                .HasForeignKey(templateElement => templateElement.TemplateId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OutputPath>(entity =>
            {
                entity.
                HasOne(outputPath => outputPath.ParentBellRing)
                .WithMany(bellring => bellring.OutputPaths)
                .HasForeignKey(outputPath => outputPath.BellRingId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

