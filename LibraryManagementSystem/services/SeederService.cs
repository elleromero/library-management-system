using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.services
{
    internal class SeederService : EnvService
    {
        // This class inserts and creates initial data to the database
        public static void CreateInitialTable()
        {
            // check if the the database exists and has no tables
            SqlCommand sqlCommand = new SqlCommand();
        }

        public static bool CreateDatabase() {
            bool isDBCreated = false;

            // check if database already exists
            if (!IsDatabaseExist(GetDBName()))
            {
                string query = $"CREATE DATABASE {GetDBName()};";

                SqlClient.Execute((isError, conn) =>
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    try
                    {
                        command.ExecuteScalar();
                    }
                    catch { isDBCreated = false; }
                }, true);

                isDBCreated = true;
            }

            return isDBCreated;
        }

        private static bool IsDatabaseExist(string dbName)
        {
            bool isExists = true;

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    string query = $"SELECT DB_ID('{dbName}') AS db_id;";
                    SqlCommand command = new SqlCommand(query, conn);

                    try
                    {
                        object dbId = command.ExecuteScalar();

                        isExists = dbId != DBNull.Value;
                    }
                    catch { isExists = true; }
                }
                else isExists = false;
            }, true);

            return isExists;
        }

        private static bool AreTablesExist(string dbName)
        {
            bool isExists = true;

            SqlClient.Execute((error, conn) =>
            {
                if (error == null)
                {
                    string query = $"SELECT COUNT(*) FROM information_schema.tables WHERE table_catalog = '{dbName}';";
                    SqlCommand command = new SqlCommand(query, conn);

                    try
                    {
                        int count = (int)command.ExecuteScalar();

                        isExists = count > 0;
                    }
                    catch { isExists = true; }
                }
                else isExists = false;
            }, true);

            return isExists;
        }
    }
}
