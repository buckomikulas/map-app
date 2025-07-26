namespace map_app_api.Models
{
    public class Route
    {
        public int route_id { get; set; }
        public required string name { get; set; }
        public required string location { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }

    }
}
