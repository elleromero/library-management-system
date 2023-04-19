using LibraryManagementSystem.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Member : IModel
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Member(string id, string name, string address, string phone, string email = "")
        {
            tableName = "members";
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string tableName { get; set; }
    }
}
