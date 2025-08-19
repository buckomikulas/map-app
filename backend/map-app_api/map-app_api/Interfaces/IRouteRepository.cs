using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IRouteRepository
    {
        ICollection<Models.Route> GetRoutes();
        Models.Route? GetRoute(string name);
        Models.Route? GetRoute(int id);
        bool RouteExists(string name);
        bool RouteExists(int id);

        ICollection<Stop> GetStopsOnRoute(int id);
        bool AddStopToRoute(int routeId, List<Stop> stop);
        bool DeleteRoute(Models.Route route);
        bool Save();
    }
}
