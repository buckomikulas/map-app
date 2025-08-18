using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IUserRouteRepository
    {
        bool CreateUserRoute(UserRoute userRoute);
        bool Save();
    }
}
