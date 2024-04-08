using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Admin(string username, string password) 
        {
            this.Username = username;
            this.Password = password;
        }

    }
}
