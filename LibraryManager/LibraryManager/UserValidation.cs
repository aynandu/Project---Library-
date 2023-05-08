using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class UserValidation
    {
        
        public void UsrValidation(string usrName, string pwd)
        {
            UserInfo userInfo = new UserInfo();
            User status = new User();
            MainMenu mainMenu = new MainMenu();
            Login login;
            var userDetails = from user in userInfo.GetUserInfo()
                              select user;

            foreach (var user in userDetails)
            {
                if(user.Username== usrName && user.Password==pwd)
                {

                    if (user.status == (status.LoggedIN = User.LoggedInStatus.admin))
                    {
                        Console.Clear();
                        login = new Login();
                        login.title();
                        Console.WriteLine($"\nHi , {user.Name} ({user.status})");
                        mainMenu.AdminMenu();
                    }
                    if (user.status == (status.LoggedIN = User.LoggedInStatus.local))
                    {
                        Console.Clear();
                        login = new Login();
                        login.title();
                        Console.WriteLine($"\nHi , {user.Name} ({user.status})");
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
