namespace map_app_api.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public required string Name { get; set; }

        public ICollection<RouteTag> RouteTags { get; set; } = new List<RouteTag>();
    }
}
