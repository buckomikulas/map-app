using map_app_api.Data;
using map_app_api.Interfaces;
using map_app_api.Models;
using System.Runtime.InteropServices.ObjectiveC;

namespace map_app_api.Repository
{
    public class UserRouteRepository : IUserRouteRepository
    {
        private readonly DataContext m_dataContext;
        public UserRouteRepository(DataContext dataContext)
        {
            m_dataContext = dataContext;
        }
        public bool CreateUserRoute(UserRoute userRoute)
        {
            m_dataContext.UserRoutes.Add(userRoute);
            return Save();
        }

        public bool Save()
        {
            return m_dataContext.SaveChanges() > 0; // Save changes to the database and return true if successful
        }
    }
}
