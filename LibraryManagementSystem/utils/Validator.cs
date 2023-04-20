using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManagementSystem.utils
{
    internal class Validator
    {
        public static bool IsEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            try
            {
                var emailRegex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
                    RegexOptions.Compiled);

                return emailRegex.IsMatch(email);
            }
            catch { return false; }
        }

        public static bool IsPhone(string phone) {
            if (string.IsNullOrWhiteSpace(phone)) return false;

            try
            {
                var phoneNumberRegex = new Regex(@"^\+63[0-9]{10}$");
                return phoneNumberRegex.IsMatch(phone);
            }
            catch { return false; }
        }

        public static bool IsName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return false;

            // Remove any whitespace from the beginning and end of the string
            name = name.Trim();

            // Check if the name contains only letters and spaces
            if (!Regex.IsMatch(name, @"^[a-zA-Z' -]+$")) return false;

            // Check if the name is not too long (100 characters or less)
            if (name.Length > 50) return false;

            return true;
        }

        public static bool IsUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            // Check if the username contains only letters, numbers, underscores, or hyphens
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_-]+$"))
                return false;

            // Check if the username is not too long (50 characters or less)
            if (username.Length > 50)
                return false;

            return true;
        }

        public static bool IsPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            if (password.Length < 6) return false;

            return true;
        }


    }
}
