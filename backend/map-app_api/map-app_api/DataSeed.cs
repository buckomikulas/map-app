using map_app_api.Data;
using map_app_api.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace map_app_api
{
    public class DataSeed
    {

        private readonly DataContext m_context;

        public DataSeed(DataContext context)
        {
            m_context = context;
        }
        public void ClearData()
        {
            m_context.UserRoutes.RemoveRange(m_context.UserRoutes);
            m_context.RouteTags.RemoveRange(m_context.RouteTags);
            m_context.Stops.RemoveRange(m_context.Stops);
            m_context.Routes.RemoveRange(m_context.Routes);
            m_context.Users.RemoveRange(m_context.Users);
            m_context.Tags.RemoveRange(m_context.Tags);
            m_context.SaveChanges();
        }


        public void SeedData()
        {
            // Check if the database is empty
            if (!m_context.Users.Any() && !m_context.Routes.Any())
            {
                // Create test data
                var user1 = new User { Name = "John" };
                var user2 = new User { Name = "Christine" };

                var route1 = new Models.Route { Name = "Test route", 
                                                Location = "Test location", 
                                                From = new DateTime(2005, 8, 7), 
                                                To = new DateTime(2025, 8, 14), };

                var route2 = new Models.Route { Name = "Dream path",
                                                Location = "Paris",
                                                From = new DateTime(2025, 7, 7),
                                                To = new DateTime(2025, 7, 14)};

                var tag1 = new Tag { Name = "Historic" };
                var tag2 = new Tag { Name = "Modern" };
                var tag3 = new Tag { Name = "Architecture" };

                // Add data to the context
                m_context.Users.AddRange(user1, user2);
                m_context.Routes.AddRange(route1, route2);
                m_context.Tags.AddRange(tag1, tag2, tag3);
                m_context.SaveChanges();


                // Create relationships
                var userRoutes = new List<UserRoute>
                {
                    new UserRoute { User = user1, Route = route1 },
                    new UserRoute { User = user1, Route = route2 }
                };

                var routeTags = new List<RouteTag>
                {
                    new RouteTag { Route = route1, Tag = tag1 },
                    new RouteTag { Route = route1, Tag = tag2 },
                    new RouteTag { Route = route2, Tag = tag3 }
                };

                // Add relationships to the context
                m_context.UserRoutes.AddRange(userRoutes);
                m_context.RouteTags.AddRange(routeTags);

                var route1Stops = new List<Stop>
                {
                    new Stop { Name = "RouteStop 1", Route = route1, TimeSpend = new TimeSpan(1,0,0), Fact = "An interesting fact"},
                    new Stop { Name = "RouteStop 2", Route = route1, TimeSpend = new TimeSpan(1,30,0), Fact = "Not so interesting fact"},
                };

                var route2Stops = new List<Stop>
                {
                    new Stop { Name = "RouteStop 3", Route = route2, TimeSpend = new TimeSpan(4,0,0), Fact = "Facts"},
                    new Stop { Name = "RouteStop 4", Route = route2, TimeSpend = new TimeSpan(2,30,0), Fact = "FUnny fact"},
                };

                m_context.Stops.AddRange(route1Stops.Concat(route2Stops));
                m_context.SaveChanges();


            }

        }

    }
}
