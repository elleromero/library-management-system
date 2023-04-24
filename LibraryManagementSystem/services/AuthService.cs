using LibraryManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.services
{
    internal class AuthService
    {
        private static User? signedInUser = default(User);

        public static User? getSignedUser()
        {
            return signedInUser;
        }

        public static void setSignedUser(User user)
        {
            signedInUser = user;
        }
    }
}
