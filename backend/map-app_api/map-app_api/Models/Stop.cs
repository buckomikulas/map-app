namespace map_app_api.Models
{
    //NEED TO ADD LAT/LNG FOR STOP

    // Entity depending on the route
    public class Stop
    {
        // Composed PK
        public int StopId { get; set; }
        public int RouteId { get; set; }
        

        public required string Name { get; set; }
        public TimeSpan TimeSpend { get; set; }
        public string? Fact { get; set; }
        public string? Tip { get; set; }

        public required Route Route { get; set; }
    }
}
