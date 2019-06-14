using MassReconApi.Infrastucture.Model;
using Microsoft.EntityFrameworkCore;

namespace MassReconApi.Infrastucture.Context
{
    public class MassReconContext : DbContext
    {
        public DbSet<Report> Report { get; set; }
        public DbSet<ReportItem> ReportItem { get; set; }
        public DbSet<ReconNote> ReconNote { get; set; }
        
        public MassReconContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.MassReconApi.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>()
                .HasMany(x => x.ReportItems)
                .WithOne(y => y.Report)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}