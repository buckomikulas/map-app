using AutoMapper;
using map_app_api.Dto;
using map_app_api.Models;

namespace map_app_api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>().ForMember(dest => dest.RouteIds,
                                                 opt => opt.MapFrom(src => src.UserRoutes.Select(ur => ur.RouteId))); 
        }
    }
}
