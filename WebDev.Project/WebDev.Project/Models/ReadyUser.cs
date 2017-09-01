namespace WebDev.Project.Models
{
    public class ReadyUser
    {
        public ReadyUser(int id, string username, string passwordHash, string name, string email, bool isAdmin)
        {
            this.Id = id;
            this.UserName = username;
            this.PasswordHash = passwordHash;
            this.Name = name;
            this.Email = email;
            this.IsAdmin = isAdmin;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}