namespace map_app_api.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
