namespace map_app_api.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        // Relations
        public ICollection<Stop> Stops { get; set; } = new List<Stop>();
        public ICollection<UserRoute> UserRoutes { get; set; } = new List<UserRoute>(); 
        public ICollection<RouteTag> RouteTags { get; set; } = new List<RouteTag>();

    }
}
