namespace map_app_api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; } 

        // User doesn't have to add their surname
        public string? Surname { get; set; }

        // Change later to standalone tables and add dependencies
        public int Hobby { get; set; }
        public int TravellingType { get; set; }
        public int RouteType { get; set; }
        public int Companions { get; set; }


    }
}
