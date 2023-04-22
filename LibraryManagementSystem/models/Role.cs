using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Role
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasAccess { get; set; }
    }
}
