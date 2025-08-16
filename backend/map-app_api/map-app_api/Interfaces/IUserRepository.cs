using map_app_api.Models;

namespace map_app_api.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();  
    }
}
