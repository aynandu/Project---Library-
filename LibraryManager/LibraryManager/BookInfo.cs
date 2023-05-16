using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class BookInfo
    {
        private int DBBookID { get; set; }
        Login login = new Login();
        Book book = new Book();
        User user = new User();
        public void DisplayBookInfo(int userId)
        {

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
            AddToCart(userId);
        }
        public void AddToCart(int userId)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.Write("\nChoose Book using Book ID:");
            UserValidation userValidation = new UserValidation();

            string query = "SELECT * FROM [Book]";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int inSearchCount = 0;
            bool inSearch = true;
            try
            {
                book.BookID = int.Parse(Console.ReadLine());
                while (inSearch)
                {
                    reader.Read();

                    DBBookID = reader.GetInt32(0);

                    if (book.BookID == DBBookID)
                    {
                        if (reader.GetString(5) == "AVAILABLE")
                        {
                            reader.Close();

                            string sqlquery = "UPDATE Book SET Quantity -=1 WHERE BookId = " + book.BookID + "";
                            SqlCommand command = new SqlCommand(sqlquery, connection);

                            string sqlquery2 = "INSERT INTO [BookRent] (userID,BookID) VALUES (" + userId + "," + book.BookID + ")";
                            SqlCommand command2 = new SqlCommand(sqlquery2, connection);

                            command.ExecuteNonQuery();
                            command2.ExecuteNonQuery();

                            Console.WriteLine("Congrats, Book Added to Your Cart\n Click Enter Main Menu\n");
                            inSearchCount = 1;
                            inSearch = false;
                            //userValidation.UsrValidation(login.userName, login.password);

                        }
                        else
                        {
                            if (reader.GetInt32(6) != 1)
                            {
                                reader.Close();
                                string sqlquery = "UPDATE Book SET Queue =1,QueueUser=" + userId + " WHERE BookId = " + book.BookID + "";
                                SqlCommand command = new SqlCommand(sqlquery, connection);
                                command.ExecuteNonQuery();
                            }
                            Console.WriteLine("Sorry Book is Not Available.Added to Queue. \n Click Enter Main Menu\n");
                            inSearchCount = 1;
                            Console.ReadLine();
                            //userValidation.UsrValidation(login.userName, login.password);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Provide a Numeric Value.");
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            if (inSearchCount == 0)
            {
                Console.WriteLine("Book Not Found");
                Console.WriteLine("Try Again\n Click Enter Main Menu\n");
            }

            Console.ReadLine();
            userValidation.UsrValidation(login.userName, login.password);


        }
        public void MyCart(int userId)
        {

            Console.WriteLine("My Books:\n");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT br.BookID,b.BookName,br.[DateofRent],br.userID FROM  BookRent br JOIN [user] u ON u.UserID=br.userID JOIN Book b ON br.BookID=b.BookId WHERE br.userID=" + userId + "";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            int inMyCart = 0;
            while (reader.Read())
            {
                if (reader.GetInt32(3) != null)
                {
                    Console.WriteLine($"|Book ID: {reader.GetInt32(0)}| |Book Name: {reader.GetString(1)} |Date Of Rent: {reader.GetDateTime(2)} |UserID: {reader.GetInt32(3)} |\n ");
                    inMyCart = 1;
                }

            }
            if (inMyCart == 0)
            {
                Console.WriteLine("Your Cart Is Empty, Go to View Books to Add Books to Cart.");
            }
            Console.Write("\n");
            connection.Close();

        }

        public void AddToStock()
        {

            Book book = new Book();
            Console.WriteLine("Add Stock\n");
            Console.Write("\nEnter Book Name : ");
            book.BookName = Console.ReadLine();
            Console.Write("\nEnter AuthorName : ");
            book.AuthorName = Console.ReadLine();
            Console.Write("\nEnter Book Details : ");
            book.About = Console.ReadLine();
            Console.Write("\nEnter Quantity : ");
            book.Quantity = int.Parse(Console.ReadLine());
            Console.Clear();
            login.title();
            Console.WriteLine("Books :\n");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlquery = "INSERT INTO [Book] (BookName,AuthorName,About,Quantity) VALUES ('" + book.BookName + "','" + book.AuthorName + "','" + book.About + "','" + book.Quantity + "')";
            SqlCommand command = new SqlCommand(sqlquery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Stock Add,Please Click enter to Login");
            Console.ReadLine();
        }
        public void SortBook(int userId)
        {

            Console.WriteLine("Sort Books by Available :\n");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [Book] WHERE Status ='AVAILABLE'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"|Book ID: {reader.GetInt32(0)}| |Book Name: {reader.GetString(1)} |Author Name: {reader.GetString(2)} |Quantity: {reader.GetInt32(4)} |Status:{reader.GetString(5)}\n ");
            }
            Console.Write("\nChoose Book using Book ID:");
            connection.Close();
            AddToCart(userId);
        }
        public void StockAutomation()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT br.BookID ,br.userID,bk.Queue FROM BookRent br JOIN Book bk ON  br.BookID=bk.BookId WHERE br.DueDate=CAST(GETDATE() as DATE);";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            bool isStockatmCount = true;

            while (isStockatmCount)
            {
                try
                {
                    reader.Read();
                    book.BookID = reader.GetInt32(0);
                    user.UserID = reader.GetInt32(1);
                    int Queue = reader.GetInt32(2);
                    if (Queue == 1)
                    {

                        reader.Close();
                        string Query2 = "INSERT INTO BookRent(BookID,userID) VALUE(" + book.BookID + ",(SELECT QueueUser  FROM Book WHERE Queue =1));DELETE  FROM BookRent WHERE userID=" + user.UserID + "  AND BookID = " + book.BookID + ";UPDATE Book SET Queue=0,QueueUser=Null Where BookId =" + book.BookID + " ;";
                        SqlCommand command2 = new SqlCommand(Query2, connection);
                        command2.ExecuteNonQuery();
                    }
                    if (Queue == 0)
                    {

                        reader.Close();
                        string Query2 = "DELETE  FROM BookRent WHERE userID=" + user.UserID + "  AND BookID = " + book.BookID + ";UPDATE Book SET Quantity+=1 Where BookId =" + book.BookID + " ;";
                        SqlCommand command2 = new SqlCommand(Query2, connection);
                        command2.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    isStockatmCount = false;
                }

            }
            connection.Close();
        }
        public void ExtendBookPeriod(int userId)
        {
            bool isextendCount = true;
            while (true)
            {

                try 
                {
                    Console.Clear();
                    login.title();
                    StockAutomation();
                    MyCart(userId);
                    
                
                        Console.Write("\nExtend Your Book By Choose by BookID :");
                        book.BookID = int.Parse(Console.ReadLine());

                        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();

                        string query = "UPDATE BookRent SET ExtendDate=CAST(GETDATE() as DATE),DueDate=dateadd(day,(2),getdate()) WHERE BookID= " + book.BookID + " AND userID=" + userId + "";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        
                        Console.WriteLine("Period Extended");
                        cmd.ExecuteNonQuery();
                        break;
                        connection.Close();
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please provide the Correct BookID ");
                }
            }
        }
    }
}
