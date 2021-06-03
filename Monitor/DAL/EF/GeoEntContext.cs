using DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class GeoEntContext
        : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Reagent> Reagents { get; set; }

        public GeoEntContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}