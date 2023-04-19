using LibraryManagementSystem.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Status : IModel
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Status(string id, string name, string description)
        {
            tableName = "statuses";
            ID = id;
            Name = name;
            Description = description;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string tableName { get; set; }
    }
}
