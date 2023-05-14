using System;
using System.Collections.Generic;
using System.Data.SqlClient; //Sql Library
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class UserInfo
    {
        Login login = new Login();
        User user = new User();

        public void AddNewuser()
        {
            
            
            Console.Clear();
            login.title();
            Console.WriteLine("Signup  ");
            Console.Write("\nEnter Your Name : ");
            user.Name = Console.ReadLine();
            Console.Write("\nEnter MobileNumber : ");
            user.MobileNumber = int.Parse(Console.ReadLine());
            Console.Write("\nEnter User Name : ");
            user.Username = Console.ReadLine().ToLower();
            Console.Write("\nEnter Password : ");
            user.Password = Console.ReadLine().ToLower();

            //1.Address of SQL server and Database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";

            //2.Establish Connection
            SqlConnection connection = new SqlConnection(connectionString);
            //3. open Connection 
            connection.Open();
            //4.Prepare Query
            string sql = "INSERT INTO [user] (Name,MobileNumber,UserName,Password) VALUES ('" + user.Name + "','" + user.MobileNumber + "','" + user.Username + "','" + user.Password + "')";
            //5.Execute query
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            //6.Connection closed
            connection.Close();
            Console.WriteLine("Signup Completed,Please Click enter to Login");
            Console.ReadLine();
            login.DisplayLoginMenu();

        }

        public void UserDetails()
        {
            Console.Clear();
            login.title();
            //1.Address of SQL server and Database
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";

            //2.Establish Connection - connect object
            SqlConnection connection = new SqlConnection(connectionString);
            //3. open Connection 
            connection.Open();
            //4.Prepare Query
            string sqlQuery = "SELECT * FROM [user]";
            //5.Execute query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("UserID: {0}, Name: {1}, Status: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(5));
            }
           // reader.Close();

            //6.Connection closed
            connection.Close();
                                 
        }
        public void DeleteUser()
        {
            Console.Clear();
            login.title();
            UserDetails();
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";

            SqlConnection connection = new SqlConnection( connectionString);
            connection.Open();
            string sqlQuery = "SELECT * FROM [user]";
            SqlCommand command = new SqlCommand( sqlQuery, connection);
            SqlDataReader reader = command.ExecuteReader();
           
            bool isDeleteUserCount = true;
            bool innerCount = true;
            int noUser = 0;
            while (isDeleteUserCount)
            {
                
                try
                {
                    Console.Write("\n Choose UserID:  ");
                    int deleteUserId = int.Parse(Console.ReadLine());
                    
                    while (innerCount)
                    {
                        reader.Read();
                        user.UserID = reader.GetInt32(0);
                        if (deleteUserId == user.UserID)
                        {
                            reader.Close();
                            string query = "DELETE  FROM [user] WHERE UserID = " + deleteUserId + " ";
                            SqlCommand sqlCommand = new SqlCommand( query, connection );
                            sqlCommand.ExecuteNonQuery();
                            Console.WriteLine($"User with UserID {deleteUserId} Succesfully Deleted.");
                            noUser = 1;
                            isDeleteUserCount = false;
                            break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Choose a numeric Value ");
                    Console.WriteLine(ex.Message);
                }

            }
            reader.Close();
            connection.Close();
            if (noUser == 0)
            {
                Console.WriteLine("User Not Found");
            }
            
        }
        public void ViewQueue()
        {
            Console.Clear();
            login.title();
            Console.WriteLine("Books :\n");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\nandu\\Desktop\\Project\\Database\\librarymanagment\\LibraryManagement DB\\LibraryManagement DB\\LibraryDB.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [Book] WHERE Queue=1";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"|Book ID: {reader.GetInt32(0)}| |Book Name: {reader.GetString(1)}|Status:{reader.GetString(5)} |User In Queue: {reader.GetInt32(7)}\n ");
            }
            connection.Close();
        }
    }
}
