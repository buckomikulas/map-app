using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IStopRepository
    {
        Stop? GetStop(int stopId, int routeId);
        Stop? GetStop(string stopName, string routeName);
        bool StopExists(string stopName, string routeName);
        bool StopExists(int stopId, int routeId);
        bool Save();
        bool DeleteStopFromRoute(int stopId, int routeId);
    }

}
