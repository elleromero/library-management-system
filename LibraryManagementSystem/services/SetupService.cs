using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagementSystem.services
{
    internal class SetupService
    {
        // NOTE: This class will initialize the database when the program first loads
        public static bool Ready()
        {
            EnvService env = new EnvService();
            using (SqlConnection conn = new SqlConnection(env.GetConnBase()))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}
