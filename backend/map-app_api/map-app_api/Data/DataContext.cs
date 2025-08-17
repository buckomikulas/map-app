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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stop>()
                .HasKey(s => new { s.StopId, s.RouteId });

            modelBuilder.Entity<Stop>()
                 .Property(s => s.StopId)
                 .ValueGeneratedOnAdd(); // Auto-increment StopId

            modelBuilder.Entity<Stop>()
                .HasOne(s => s.Route)
                .WithMany(r => r.Stops)
                .HasForeignKey(s => s.RouteId)
                .OnDelete(DeleteBehavior.Cascade); // Delete stops when the route is deleted

            // Many-to-many relationship between Routes and Tags
            modelBuilder.Entity<RouteTag>()
                .HasKey(rt => new { rt.RouteId, rt.TagId });

            modelBuilder.Entity<RouteTag>()
                .HasOne(rt => rt.Route)
                .WithMany(r => r.RouteTags)
                .HasForeignKey(rt => rt.RouteId);

            modelBuilder.Entity<RouteTag>()
                .HasOne(rt => rt.Tag)
                .WithMany(t => t.RouteTags)
                .HasForeignKey(rt => rt.TagId);

            // Many-to-many relationship between Users and Routes
            modelBuilder.Entity<UserRoute>()
                .HasKey(ur => new { ur.UserId, ur.RouteId });

            modelBuilder.Entity<UserRoute>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoutes)
                .HasForeignKey(ur => ur.UserId);    

            modelBuilder.Entity<UserRoute>()
                .HasOne(ur => ur.Route)
                .WithMany(r => r.UserRoutes)
                .HasForeignKey(ur => ur.RouteId);

            // User name is not nullable
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            // Route name and location are not nullable
            modelBuilder.Entity<Models.Route>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Models.Route>()
                .Property(r => r.Location)
                .IsRequired();

            // Stop name is not nullable
            modelBuilder.Entity<Stop>()
                .Property(s => s.Name)
                .IsRequired();

            // Tag name is not nullable
            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired();  

        }


    }
}
