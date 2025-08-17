using map_app_api.Data;
using map_app_api.Models;
using map_app_api.Interfaces;
using Azure.Core;

namespace map_app_api.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DataContext m_dataContext;

        // Constructor injection for DataContext
        public RouteRepository(DataContext dataContext)
        {
            m_dataContext = dataContext;
        }

        public Models.Route? GetRoute(string name)
        {
            return m_dataContext.Routes.FirstOrDefault(r => r.Name == name);   
        }

        public Models.Route? GetRoute(int id)
        {
            return m_dataContext.Routes.FirstOrDefault(r => r.RouteId == id);
        }

        public ICollection<Models.Route> GetRoutes()
        {
            return m_dataContext.Routes.OrderBy(r => r.RouteId).ToList();  
        }

        public ICollection<Stop> GetStopsOnRoute(int id)
        {
            return m_dataContext.Stops.Where(s=> s.RouteId == id).OrderBy(s => s.StopId).ToList();
        }

        public bool RouteExists(string name)
        {
            return m_dataContext.Routes.Any(r => r.Name == name);
        }

    }
}
