using map_app_api.Data;
using map_app_api.Models;
using map_app_api.Interfaces;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

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
            return m_dataContext.Stops.Where(s => s.RouteId == id).OrderBy(s => s.StopId).ToList();
        }

        public bool RouteExists(string name)
        {
            return m_dataContext.Routes.Any(r => r.Name == name);
        }

        //----------------------------------------------------------------
        public bool AddStopToRoute(int routeId, List<Stop> stop)
        {
            var route = m_dataContext.Routes.Include(r => r.Stops)
                                           .FirstOrDefault(r => r.RouteId == routeId);

            if (route == null) return false;

            foreach (var s in stop)
            {
                // Check if the stop already exists on the route
                if (route.Stops.Any(existingStop => existingStop.Name == s.Name))
                {
                    continue; // Skip adding this stop if it already exists
                }
                // Add the new stop to the route
                route.Stops.Add(s);
                m_dataContext.Stops.Add(s);
            }

            return m_dataContext.SaveChanges() > 0;
        }
    }
}
