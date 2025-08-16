using map_app_api.Models;

namespace map_app_api.Dto
{
    public class RouteDTO
    {
        public int RouteId { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<Stop> Stops { get; set; } = new List<Stop>();

    }
}
