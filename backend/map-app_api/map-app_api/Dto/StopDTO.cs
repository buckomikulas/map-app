namespace map_app_api.Dto
{
    public class StopDTO
    {
        public int StopId { get; set; }
        public int RouteId { get; set; }
        public required string Name { get; set; }
        public TimeSpan TimeSpend { get; set; }
        public string? Fact { get; set; }
        public string? Tip { get; set; }

    }
}
