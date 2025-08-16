using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IRouteRepository
    {
        ICollection<Models.Route> GetRoutes();
        Models.Route? GetRoute(string name);
        Models.Route? GetRoute(int id);
        bool RouteExists(int id);
        ICollection<Stop> GetStopsOnRoute(int id);
    }
}
