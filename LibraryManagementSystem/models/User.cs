using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class User
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public User(string iD, string roleID, string memberID, string username, string password)
        {
            ID = iD;
            RoleID = roleID;
            MemberID = memberID;
            Username = username;
            Password = password;
        }

        public string ID { get; set; }
        public string RoleID { get; set; }
        public string MemberID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
