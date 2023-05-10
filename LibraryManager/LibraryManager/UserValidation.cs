using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManager
{
     class UserValidation
    {
        
        public void UsrValidation(string usrName, string pwd)
        {
            
            Login login;
            MainMenu mainMenu = new MainMenu();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlQuery = "SELECT * FROM [user]";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            User user=new User();
            
            while (reader.Read())
            {               
                user.Username = reader.GetString(3);
                user.Password = reader.GetString(4);
                user.Status = reader.GetString(5);
                if (user.Username == usrName && user.Password == pwd)
                {

                    if (user.Status == "admin")
                    {
                        Console.Clear();
                        login = new Login();
                        login.title();
                        Console.WriteLine($"\nHi , {reader.GetString(1)} ({reader.GetString(5)}\n)");
                        mainMenu.AdminMenu();
                    }
                    if (user.Status == "Local")
                    {
                        Console.Clear();
                        login = new Login();
                        login.title();
                        Console.WriteLine($"\nHi , {reader.GetString(2)} ({reader.GetString(5)}\n)");
                        mainMenu.LocalMenu();
                    }
                  
                }
                else
                {
                    Console.WriteLine("Invalid User! Click Enter to Home.");
                    Console.ReadLine();
                    login = new Login();
                    login.DisplayLoginMenu();
                    
                }
            }
            Console.ReadLine();
            
        }
     }
}
