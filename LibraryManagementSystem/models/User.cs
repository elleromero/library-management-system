using LibraryManagementSystem.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class User : IModel
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public User(string iD, string roleID, string memberID, string username, string password)
        {
            tableName = "users";
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
        public string tableName { get; set; }
    }
}
