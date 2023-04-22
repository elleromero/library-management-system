using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        // Foreign keys
        public Role Role { get; set; } = new Role();
        public Member Member { get; set; } = new Member();
    }
}
