using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (string.IsNullOrWhiteSpace(username)) return false;

            // Check if the username contains only letters, numbers, underscores, or hyphens
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_-]+$")) return false;

            // Check if the username is not too long (50 characters or less)
            if (username.Length > 50) return false;

            return true;
        }

        public static bool IsUsernameUnique(string username)
        {
            // Check if username is unique
            bool isUnique = false;
            SqlClient.Execute((error, conn) =>
            {
                try
                {
                    if (error == null)
                    {
                        string query = $"SELECT COUNT(*) FROM users WHERE username = '{username}'";
                        SqlCommand command = new SqlCommand(query, conn);

                        int count = (int)command.ExecuteScalar();

                        isUnique = count == 0;
                    } else return;
                }
                catch { return; }
            });

            return isUnique;
        }

        public static bool IsPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            if (password.Length < 6) return false;

            return true;
        }

        public static bool IsGenreIdValid(int genreId)
        {
            bool isValid = false;
            SqlClient.Execute((error, conn) =>
            {
                try
                {
                    if (error == null)
                    {
                        string query = $"SELECT COUNT(*) FROM genres WHERE genre_id = {genreId}";
                        SqlCommand command = new SqlCommand(query, conn);

                        int count = (int)command.ExecuteScalar();

                        isValid = count > 0;
                    }
                    else return;
                } catch { return; }
            });

            return isValid;
        }

        public static bool IsDateBeforeOrOnPresent(DateTime date)
        {
            DateTime currentDate = DateTime.Now;
            return date <= currentDate;
        }

        public static bool IsValidISBN(string isbn)
        {
            // Remove any hyphens or spaces from the input string
            isbn = isbn.Replace("-", "").Replace(" ", "");

            // An ISBN must be 10 or 13 digits long
            if (isbn.Length != 10 && isbn.Length != 13)
            {
                return false;
            }

            // Check if the last character is an X (only valid for ISBN-10)
            if (isbn.Length == 10 && isbn[9] == 'X')
            {
                isbn = isbn.Substring(0, 9) + "10";
            }

            // Check if all characters are digits (except for the last one in ISBN-10)
            for (int i = 0; i < isbn.Length; i++)
            {
                if (i == 9 && isbn.Length == 10)
                {
                    break;
                }
                if (!Char.IsDigit(isbn[i]))
                {
                    return false;
                }
            }

            // Calculate the check digit for ISBN-10
            if (isbn.Length == 10)
            {
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (i + 1) * int.Parse(isbn[i].ToString());
                }
                int checkDigit = sum % 11;
                if (checkDigit == 10 && isbn[9] != 'X' || checkDigit != int.Parse(isbn[9].ToString()))
                {
                    return false;
                }
            }

            // Calculate the check digit for ISBN-13
            if (isbn.Length == 13)
            {
                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += (i % 2 == 0 ? 1 : 3) * int.Parse(isbn[i].ToString());
                }
                int checkDigit = (10 - sum % 10) % 10;
                if (checkDigit != int.Parse(isbn[12].ToString()))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
