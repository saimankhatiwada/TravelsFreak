using Microsoft.EntityFrameworkCore;

namespace TravelsFreak.Data.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Destinations> Destinations { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
