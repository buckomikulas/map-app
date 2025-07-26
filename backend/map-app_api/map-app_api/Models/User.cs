namespace map_app_api.Models
{
    public class User
    {
        public int user_id { get; set; }
        public required string name { get; set; } 

        // User doesn't have to add their surname
        public string? surname { get; set; }

        // Change later to standalone tables and add dependencies
        public int hobby { get; set; }
        public int travelling_type { get; set; }
        public int route_type { get; set; }
        public int companions { get; set; 
        }


    }
}
