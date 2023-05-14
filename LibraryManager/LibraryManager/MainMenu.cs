using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class MainMenu
    {
        BookInfo bookInfo = new BookInfo();
        Login login=new Login();
        public void DisplayMainMenu() // just started 
        {
           
                Console.Clear();           
                login.title();
        }

        public void AdminMenu(int userId)
        {
            try
            {
                
                Console.WriteLine("Option 1: View Book\nOption 2: Add Stock\nOption 3: My Cart \nOption 4: Extent the Period" +
                    "\nOption 5: View Queue \nOption 6: Search \nOption 7: Sort \nOption 8: View User \nOption 9: Delete User \nOption 10: Exit");
                Console.Write("\nChoose a Option : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        bookInfo.DisplayBookInfo(userId);
                        break;
                    case 2:
                        bookInfo.AddToStock();
                        break;
                    case 3:
                        bookInfo.MyCart(userId);
                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:
                        UserInfo userInfo = new UserInfo();
                        userInfo.UserDetails();
                        break;
                    case 9:

                        break;
                    case 10:
                        Console.WriteLine("Click Enter to Close.");
                        break;
                    default:
                        Console.WriteLine("Please Choose the Correct Option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Provide a Numeric Value.");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        public void LocalMenu(int userId)
        {
            try
            {                
                Console.WriteLine("Option 1: View Book\nOption 2: My Cart\nOption 3: Extent the Period" +
                    "\nOption 4: Search \nOption 5: Sort \nOption 6: Exit");
                Console.Write("\nChoose a Option : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        bookInfo.DisplayBookInfo(userId);
                        break;
                    case 2:
                        bookInfo.MyCart(userId);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:
                        Console.WriteLine("Click Enter to Close.");
                        break;
                    default:
                        Console.WriteLine("Please Choose the Correct Option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Provide a Numeric Value.");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        public void GuestMenu()
        {
            try
            {
                Console.Clear();
              
                login.title();
                Console.WriteLine("Option 1: View Book\nOption 2: Search \nOption 3: Sort \nOption 4: Back to Main Menu");
                Console.Write("\nChoose a Option : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
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
                        Console.Write("\nChoose Book using Book ID:");
                        connection.Close();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        Console.WriteLine("Click Enter to Back.");
                        break;
                    default:
                        Console.WriteLine("Please Choose the Correct Option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Provide a Numeric Value.");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
