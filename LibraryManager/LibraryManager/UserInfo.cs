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
        public List<User> userInfo = new List<User>()
                {
                     new User{Name="Barry Allan",UserID=101,MobileNumber=1234567891,Username="barry",Password="barry",LoggedIN=User.LoggedInStatus.admin},
                     new User{Name="Iris West",UserID=102,MobileNumber=1234567892,Username="iris",Password="iris",LoggedIN=User.LoggedInStatus.local},
                     new User{Name="Cisco Ramon",UserID=103,MobileNumber=1234567895,Username="cisco",Password="cisco",LoggedIN=User.LoggedInStatus.local},
                     new User{Name="Catlin Snow",UserID=104,MobileNumber=1234567893,Username="catlin",Password="catlin",LoggedIN=User.LoggedInStatus.local},
                     new User{Name="Dr.Harry Wells",UserID=105,MobileNumber=1234567894,Username="wells",Password="wells",LoggedIN=User.LoggedInStatus.local},
                };
        public List<User>  GetUserInfo()
        {
            return userInfo;
        }
        public void AddNewuser()
        {
            
            User user = new User();
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

            /*SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            reader.Close();
            */
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
            Console.WriteLine("\nPlease Click enter to Main Menu");
            Console.ReadLine();
            
        }
    }
}
