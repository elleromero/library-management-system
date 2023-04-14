using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Book
    {
        // TODO: Only generate and retrieve keys from the query. Remove primary and foreign keys later
        // TODO: Add sypnosis field to the erd
        public Book(string id, string categoryID, string title, string sypnosis, string author, string cover, string publisher, DateTime publicationDate, string isbn)
        {
            ID = id;
            CategoryID = categoryID;
            Title = title;
            Sypnosis = sypnosis;
            Author = author;
            Cover = cover;
            Publisher = publisher;
            PublicationDate = publicationDate;
            ISBN = isbn;
        }

        public string ID { get; set; }
        public string CategoryID { get; set; }
        public string Title { get; set; }
        public string Sypnosis { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
    }
}
