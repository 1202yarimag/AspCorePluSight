using AspCorePluSight.Models;
using Microsoft.EntityFrameworkCore;


namespace AspCorePluSight.Data
{
    public class OdeToFodDbContext:DbContext
    {
        public OdeToFodDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet <Restaurant> Restaurants { get; set; }

        public DbSet<Auto> Autos{ get; set; }

        public DbSet<Student> Students { get; set; }

    }
}
