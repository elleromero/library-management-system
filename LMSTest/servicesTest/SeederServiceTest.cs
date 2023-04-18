using LibraryManagementSystem.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSTest.servicesTest
{
    [TestClass]
    public class SeederServiceTest
    {
        [TestMethod]
        public void Should_Create_DB()
        {
           Assert.IsTrue(SeederService.CreateDatabase());
        }
        public void Should_Create_Tables()
        {
            Assert.IsTrue(SeederService.CreateInitialTables());
        }
    }
}
