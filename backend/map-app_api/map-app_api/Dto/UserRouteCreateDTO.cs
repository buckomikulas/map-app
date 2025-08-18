using System.ComponentModel.DataAnnotations;

namespace map_app_api.Dto
{
    public class UserRouteCreateDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string? RouteName { get; set; }
        [Required]
        public string? RouteLocation { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
    }
}
