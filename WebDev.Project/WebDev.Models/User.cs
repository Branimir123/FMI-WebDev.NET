using System.Collections.Generic;

namespace WebDev.Models
{
    public class User
    {
        private ICollection<Topic> topics;
        private ICollection<Word> words;

        public User()
        {
            this.topics = new HashSet<Topic>();
            this.words = new HashSet<Word>();
        }

        public User(string userName, string passwordHash, string name, string email, string description) : this()
        {
            this.UserName = userName;
            this.PasswordHash = passwordHash;
            this.Name = name;
            this.Email = email;
            this.Description = description;
            this.AuthKey = string.Empty;
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public bool IsAdmin { get; set; }

        public string AuthKey { get; set; }

        public virtual ICollection<Topic> Topics
        {
            get { return this.topics; }
            set { this.topics = value; }
        }

        public virtual ICollection<Word> Posts
        {
            get { return this.words; }
            set { this.words = value; }
        }
    }
}