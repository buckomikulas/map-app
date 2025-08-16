using map_app_api.Data;
using map_app_api.Interfaces;
using map_app_api.Models;

namespace map_app_api.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DataContext m_dataContext;

        public UserRepository(DataContext dataContext)
        {
            m_dataContext = dataContext;
        }
        

        public ICollection<User> GetUsers()
        {
            return m_dataContext.Users.OrderBy(u => u.UserId).ToList();
        }

        public User? GetUser(int id) 
        {             
            return m_dataContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User? GetUser(string name)
        {
            return m_dataContext.Users.FirstOrDefault(u => u.Name == name);
        }

        public bool UserExists(int id)
        {
            return m_dataContext.Users.Any(u => u.UserId == id);
        }

    }
}
