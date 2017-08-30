using WebDev.Models;

namespace WebDev.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string username, string email, string name, string description);
    }
}
