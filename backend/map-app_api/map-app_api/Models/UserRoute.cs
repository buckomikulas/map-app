namespace map_app_api.Models
{
    public class UserRoute
    {
        public int UserId { get; set; }
        public int RouteId { get; set; }

        public required User User { get; set; }
        public required Route Route { get; set; }
    }
}
