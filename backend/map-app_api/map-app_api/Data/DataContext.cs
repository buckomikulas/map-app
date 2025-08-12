using map_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace map_app_api.Data
{
    public class DataContext : DbContext
    {
        // Inject DBContextOptions into base DbContext class
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        // Define DBSets for migration and querying
        public DbSet<Models.Route> Routes { get; set; }

        public DbSet<Stop> Stops { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<RouteTag> RouteTags { get; set; }

        public DbSet<UserRoute> UserRoutes { get; set; }


    }
}
