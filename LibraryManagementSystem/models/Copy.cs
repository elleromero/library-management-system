using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Copy
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Copy(string id, string bookID, string statusID)
        {
            Id = id;
            BookID = bookID;
            StatusID = statusID;
        }

        public string Id { get; set; }
        public string BookID { get; set; }
        public string StatusID { get; set; }
    }
}
