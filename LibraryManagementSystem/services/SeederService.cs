using LibraryManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.services
{
    internal class SeederService : EnvService
    {
        // This class inserts and creates initial data to the database
        public static bool CreateInitialTables()
        {
            bool areTablesCreated = false;

            // check if the the database exists and has no tables
            if (IsDatabaseExist(GetDBName()))
            {
                if (!AreTablesExist(GetDBName()))
                {
                    SqlClient.Execute((error, conn) =>
                    {
                        if (error == null)
                        {
                            try
                            {
                                string script = File.ReadAllText("../../../resources/queries/setupSQL.sql");
                                SqlCommand command = new SqlCommand(script, conn);

                                command.ExecuteScalar();
                                areTablesCreated = true;
                            } catch { areTablesCreated = false; }
                        }
                        else areTablesCreated = false;
                    });
                }
            }

            return areTablesCreated;
        }

        public static bool CreateDatabase() {
            bool isDBCreated = false;

            // check if database already exists
            if (!IsDatabaseExist(GetDBName()))
            {
                string query = $"CREATE DATABASE {GetDBName()};";

                SqlClient.Execute((error, conn) =>
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    if (error == null)
                    {
                        try
                        {
                            command.ExecuteScalar();
                            isDBCreated = true;
                        }
                        catch { isDBCreated = false; }
                    }
                    else isDBCreated = false;
                }, true);
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
