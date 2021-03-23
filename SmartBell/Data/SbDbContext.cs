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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

