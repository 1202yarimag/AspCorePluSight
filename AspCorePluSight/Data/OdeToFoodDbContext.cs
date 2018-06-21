using AspCorePluSight.Models;
using Microsoft.EntityFrameworkCore;


namespace AspCorePluSight.Data
{
    public class OdeToFoodDbContext:DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet <Restaurant> Restaurants { get; set; }
    }
}
