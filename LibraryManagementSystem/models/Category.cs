using LibraryManagementSystem.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Category : IModel
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Category(string id, string name, string description)
        {
            tableName = "categories";
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
