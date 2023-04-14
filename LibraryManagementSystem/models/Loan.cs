using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Loan
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        public Loan(string iD, string memberID, string copyID, DateTime dateBorrowed, DateTime dueDate)
        {
            ID = iD;
            MemberID = memberID;
            CopyID = copyID;
            DateBorrowed = dateBorrowed;
            DueDate = dueDate;
        }

        public string ID { get; set; }
        public string MemberID { get; set; }
        public string CopyID { get; set; }
        public DateTime DateBorrowed { get; set; }
        public DateTime DueDate { get; set; }
    }
}
