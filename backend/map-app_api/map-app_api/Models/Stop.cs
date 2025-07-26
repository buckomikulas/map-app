namespace map_app_api.Models
{

    // Entity depending on the route
    public class Stop
    {
        public int stop_id { get; set; }
        public required string name { get; set; }
        public TimeSpan time_spend { get; set; }
        public string? fact { get; set; }
        public string? tip { get; set; }


    }
}
