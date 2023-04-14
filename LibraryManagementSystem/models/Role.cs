using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Role
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Role(string iD, string name, string hasAccess)
        {
            ID = iD;
            Name = name;
            HasAccess = hasAccess;
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string HasAccess { get; set; }
    }
}
