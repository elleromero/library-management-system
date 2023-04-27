using Isopoh.Cryptography.Argon2;
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
                    string query = "SELECT * FROM users u JOIN roles r ON u.role_id = r.role_id " +
                    $"WHERE r.has_access = 1 AND u.user_id = '${userId}'";

                    query += isStrict ? $" AND password = {Argon2.Hash(password)};" : ";";

                    try
                    {
                        SqlCommand command = new SqlCommand(query, conn);
                        int count = (int)command.ExecuteScalar();

                        isAllowed = count != 0;
                    }
                    catch { return; }
                }
            });

            return isAllowed;
        }
    }
}
