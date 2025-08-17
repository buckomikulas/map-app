using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IStopRepository
    {
        Stop? GetStop(int stopId, int routeId);
    }
}
