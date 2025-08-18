using System.ComponentModel.DataAnnotations;

namespace map_app_api.Dto
{
    public class AddStopsDTO
    {
        [Required]
        public int RouteId { get; set; }

        [Required]
        public required List<StopDTO> Stops { get; set; }
    }


}
