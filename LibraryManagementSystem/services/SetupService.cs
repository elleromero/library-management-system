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
            try
            {
                SeederService.CreateDatabase();
                SeederService.CreateInitialTables();

                return true;
            } catch { return false; }
        }
    }
}
