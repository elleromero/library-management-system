using Isopoh.Cryptography.Argon2;
using LibraryManagementSystem.models;
using LibraryManagementSystem.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.utils
{
    internal class AuthGuard
    {
        public static bool IsAdmin(bool isStrict = false, string password = "")
        {
            bool isAllowed = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            SqlClient.Execute((error, conn) =>
            {
                if (!string.IsNullOrWhiteSpace(userId) && error == null)
                {
                    Console.WriteLine("ACTIVATED");
                    string query = "SELECT * FROM users u JOIN roles r ON u.role_id = r.role_id " +
                    $"WHERE r.has_access = 1 AND u.user_id = '{userId}'";

                    Console.WriteLine(query);
                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            if (isStrict)
                            {
                                string passwordHash = reader.GetString(reader.GetOrdinal("password_hash"));
                                isAllowed = Argon2.Verify(passwordHash, password);
                            }
                            isAllowed = true;
                        }
                    }
                    catch (Exception e) { Console.WriteLine(e); return; }
                }
            });

            return isAllowed;
        }

        public static bool IsLoggedIn(string id)
        {
            User? user = AuthService.getSignedUser();

            if (user != null)
            {
                return user.ID.ToString() == id;
            }

            return false;
        }
    }
}
