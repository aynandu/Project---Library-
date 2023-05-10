using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            Console.Clear();
            login.title();
            Console.WriteLine("Books :\n");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [Book]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"|Book ID: {reader.GetInt32(0)}| |Book Name: {reader.GetString(1)} |Author Name: {reader.GetString(2)} |Quantity: {reader.GetInt32(4)} |Status:{reader.GetString(5)}\n ");
            }
            connection.Close();
            Console.WriteLine("\nClick Enter to Main Menu");
            Console.ReadLine();

        }
       
      }
}
