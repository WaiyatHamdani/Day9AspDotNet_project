using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day9projectASP.Models
{
    public class User
    {
        private int id;
        private int currentid = 100;
        private string email;
        private string username;
        private string password;

        public int Id 
        {
            set { id = currentid;
                currentid += 1; }
            get { return id; }
        }

        public string Email 
        {
            get { return email; }
            set { email = value; } 
        }

        public string Username 
        {
            get { return username; }
            set { username = value; } 
        }

        public string Password 
        {
            get { return password; } 
            set { password = value; }
        }
    }

    public class UserContext
    {
        private static List<User> listuser = new List<User>();

        public void setuser(User user)
        {
            listuser.Add(user);
        }

        public List<User> getuser()
        {
            return listuser;
        }
    }
}