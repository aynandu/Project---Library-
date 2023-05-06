using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class Book
    {
        public BookStatus status;
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string About { get; set; }
        public int Quantity { get; set; }
        public BookStatus Status { get { return status; } set { status = value;} }
        public enum BookStatus
        {
            Available,
            NotAvailable,
            Queue
        }
    }
}
