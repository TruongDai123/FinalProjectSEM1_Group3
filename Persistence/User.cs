using System;

namespace CTS_Persistence
{
    public class User
    {
        private Employees employees;

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public Employees Empl { get; set; }

        public User() { }
        public User(int userId, string username, string password, string type, Employees empl)
        {
            Employees E =  new Employees();
            this.UserId = userId;
            this.Username = username;
            this.Password = password;
            this.Type = type;
            this.Empl = empl;
        }

        public User(string username, string password, string type, Employees employees)
        {
            Username = username;
            Password = password;
            Type = type;
            this.employees = employees;
        }

        public override bool Equals(object obj)
        {
            User user = (User)obj;

            return UserId == user.UserId;
        }

        public override int GetHashCode()
        {
            return (UserId + Username + Password + Type + Empl).GetHashCode();
        }
    }
}