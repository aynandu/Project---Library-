using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class BookInfo
    {
        Login login =new Login();
        private List<Book> bookinfo = new List<Book>()
        {
                
                     new Book{BookName="The Flash: Rebirth",AuthorName="Geoff Johns",Quantity=2,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: The Return of Barry Allen",AuthorName="Mark Waid",Quantity=1,Status=Book.BookStatus.Available,About="1"},
                     new Book{BookName="The Flash: Born to Run",AuthorName="Mark Waid",Quantity=1,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: Terminal Velocity",AuthorName="Mark Waid",Quantity=3,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
                     new Book{BookName="The Flash: Blitz",AuthorName=" Geoff Johns",Quantity=4,Status=Book.BookStatus.Available,About="The Flash is an American television series"},
        };
        public void DisplayBookInfo()
        {
            
            var bookDetails = from buk in bookinfo
                              orderby buk.Quantity descending
                              select buk;

            Console.Clear();
            login.title();
            int i = 1;
            foreach (var buk in bookDetails)
            {              
                Console.WriteLine
                    (
                        $"Option {i} : {buk.BookName} by {buk.AuthorName} -  Left : {buk.Quantity} , Status: {buk.Status}"
                    );
                i++;
            }
            Console.ReadLine();
        }
       
      }
}
