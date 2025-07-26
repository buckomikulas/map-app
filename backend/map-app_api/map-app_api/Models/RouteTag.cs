namespace map_app_api.Models
{
    public class RouteTag
    {
        public int RouteId { get; set; }
        public int TagId { get; set; }

        public required Route Route { get; set; }
        public required Tag Tag { get; set; }   
    }
}
