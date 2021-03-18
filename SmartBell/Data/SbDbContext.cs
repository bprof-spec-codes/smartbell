using Microsoft.EntityFrameworkCore;
using Models;
using System;

namespace Data
{
    public class SbDbContext : DbContext
    {
        public SbDbContext()
        {

        }
        public SbDbContext(DbContextOptions<SbDbContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:smartbell.database.windows.net,1433;Initial Catalog=SmartBell;Persist Security Info=False;User ID=sm_admin;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Template> Templates { get; set; }
        public DbSet<BellRing> BellRings { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: ONE TO MANY FOR TEMPLATE -> BELLRINGS
        }
    }
}

