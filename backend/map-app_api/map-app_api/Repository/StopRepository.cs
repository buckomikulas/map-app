using map_app_api.Data;
using map_app_api.Interfaces;
using map_app_api.Models;

namespace map_app_api.Repository
{
    public class StopRepository : IStopRepository
    {
        private readonly DataContext m_dataContext;
        public StopRepository(DataContext dataContext)
        {
            m_dataContext = dataContext;
        }

        public Stop? GetStop(int stopId, int routeId)
        {
            return m_dataContext.Stops
                .FirstOrDefault(s => s.StopId == stopId && s.RouteId == routeId);
        }
    }
}
