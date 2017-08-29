using System.Collections.Generic;
using WebDev.Models;

namespace WebDev.Services.Contracts
{
    public interface IUserService
    {
        void Create(User user); 

        IEnumerable<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}