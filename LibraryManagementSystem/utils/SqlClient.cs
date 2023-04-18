using LibraryManagementSystem.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.utils
{
    internal class SqlClient : EnvService
    {
        public static void Execute(Action<Exception?, SqlConnection?> callback, bool useBase = false)
        {
            SqlConnection conn = new SqlConnection(useBase ? GetConnBase() : GetConnStr());
            Exception? error = null;

            try { conn.Open(); }
            catch (Exception e)
            {
                error = e;
            }

            callback(error, conn);
            conn.Close();
        }
    }
}
