using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.models
{
    internal class Book
    {
        public Guid ID { get; set; }
        public Genre Genre { get; set; } = new Genre();
        public string Title { get; set; } = string.Empty;
        public string Sypnosis { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; } = string.Empty;

    }
}
