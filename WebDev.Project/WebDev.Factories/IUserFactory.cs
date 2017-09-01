using WebDev.Models;

namespace WebDev.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string password, string email, string name);
    }
}
