using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User? GetUser(int id);
        User? GetUser(string name);
        bool UserExists(int id);
        ICollection<Models.Route> GetUserRoutes(int userId);
    }
}
