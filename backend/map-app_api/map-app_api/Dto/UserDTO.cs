namespace map_app_api.Dto
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!; // will never be null
        public string? Surname { get; set; }
        public int Hobby { get; set; }
        public int TravellingType { get; set; }
        public int RouteType { get; set; }
        public int Companions { get; set; }
        public List<int> RouteIds { get; set; } = new List<int>(); // only ids

    }
}
