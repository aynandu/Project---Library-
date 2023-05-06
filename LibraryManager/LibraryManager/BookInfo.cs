using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class BookInfo
    {
        public void DisplayBookInfo()
        {
            List<Book> book = new List<Book>()
                {
                     new Book{BookName="The Flash: Rebirth",AuthorName="Geoff Johns",Quantity=2,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: The Return of Barry Allen",AuthorName="Mark Waid",Quantity=1,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: Born to Run",AuthorName="Mark Waid",Quantity=1,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: Terminal Velocity",AuthorName="Mark Waid",Quantity=3,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: Blitz",AuthorName=" Geoff Johns",Quantity=4,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                };

            var bookDetails = from buk in book
                              orderby buk.Quantity descending
                              select buk;
            foreach (var buk in bookDetails)
            {
                Console.WriteLine
                    (
                        $"Name of Book :{buk.BookName} , Name of Author:{buk.AuthorName} , Book Left : {buk.Quantity} , Status: {buk.Status}"
                    );
            }
            Console.ReadLine();
        }
    }
}
