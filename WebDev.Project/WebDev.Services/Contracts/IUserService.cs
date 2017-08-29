using System.Collections.Generic;
using WebDev.Models;

namespace WebDev.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUserById(string id);

        User GetUserByUsername(string username);
    }
}