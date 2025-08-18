using AutoMapper;
using map_app_api.Dto;
using map_app_api.Models;

namespace map_app_api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Models.Route, RouteDTO>();
            CreateMap<Stop, StopDTO>();
            CreateMap<Tag, TagDTO>();

            CreateMap<UserRouteCreateDTO, UserRoute>()
         .ForMember(dest => dest.Route, opt => opt.MapFrom(src => new Models.Route
         {
             Name = src.RouteName,
             Location = src.RouteLocation,
             From = src.From,
             To = src.To
         }));


        }
    }
}
