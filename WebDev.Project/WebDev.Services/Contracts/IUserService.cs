using System.Collections.Generic;
using WebDev.Models;

namespace WebDev.Services.Contracts
{
    public interface IUserService
    {
        User Register(string userName, string password, string fullName, string email);

        string Login(string userName, string password);

        bool Logout(string authKey);

        bool Delete(string authKey, string password);
        
        IEnumerable<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}