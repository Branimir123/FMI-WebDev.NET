using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebDev.Data.Contracts;
using WebDev.Factories;
using WebDev.Models;
using WebDev.Services.Contracts;

namespace WebDev.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserFactory userFactory;

        public UserService(
            IRepository<User> userRepository,
            IUnitOfWork unitOfWork,
            IUserFactory userFactory)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            this.userRepository = userRepository;

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWorks");
            }

            if (userFactory == null)
            {
                throw new ArgumentNullException("userFactory");
            }

            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
            this.userFactory = userFactory;
        }

        private string CreateHash(string password)
        {
            //Calculate MD5 hash from input
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);

            //Convert byte array to hex 
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        public User Register(string userName, string password, string fullName, string email)
        {
            string passwordHash = this.CreateHash(password);

            var newUser = this.userFactory.CreateUser(userName, passwordHash, fullName, email);

            this.userRepository.Add(newUser);
            this.unitOfWork.Commit();

            return newUser;
        }

        public string Login(string userName, string password)
        {
            var user = this.userRepository.GetAll.FirstOrDefault(x => x.UserName == userName);

            //If user exists
            if (user == null)
            {
                return string.Empty;
            }

            //Password is correct
            var loginHash = this.CreateHash(password);

            if (user.PasswordHash == loginHash)
            {
                var authKey = Guid.NewGuid().ToString();

                user.AuthKey = authKey;

                this.userRepository.Update(user);
                this.unitOfWork.Commit();

                return authKey;
            }

            //Incorrect password
            return string.Empty;
        }

        public bool Logout(string authKey)
        {
            var user = this.userRepository.GetAll.FirstOrDefault(x => x.AuthKey == authKey);

            if (user == null)
            {
                return false;
            }

            user.AuthKey = string.Empty;
            this.userRepository.Update(user);
            this.unitOfWork.Commit();

            return true;
        }

        public bool Delete(string authKey, string password)
        {
            var user = this.userRepository.GetAll.FirstOrDefault(x => x.AuthKey == authKey);

            if (user == null)
            {
                return false;
            }

            var passwordHash = this.CreateHash(password);
            if (passwordHash != user.PasswordHash)
            {
                return false;
            }
            
            this.userRepository.Delete(user);
            this.unitOfWork.Commit();

            return true;
        }

        public IEnumerable<User> GetUsers()
        {
            return this.userRepository.GetAll
                .ToList();
        }

        public User GetUserById(string id)
        {
            return this.userRepository.GetById(id);
        }

        public User GetUserByUsername(string username)
        {
            return this.userRepository.GetAll.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public void EditUser(string id, string username, string name, string description)
        {
            var user = this.userRepository.GetById(id);

            if (user != null)
            {
                user.UserName = username;
                user.Name = name;
                user.Description = description;

                this.userRepository.Update(user);
                this.unitOfWork.Commit();
            }
        }
    }
}