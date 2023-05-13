using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class Login 

    {
        private string projectName = "Library Manager (Ver: 1.0)";
        public string userName;
        public string password;

        public void title()
        {
            Console.SetCursorPosition(0, 5);
            Console.WriteLine(projectName);
            for (int i = 0; i < projectName.Length; i++)
            {
                if (projectName[i] == char.Parse(" "))
                    Console.Write(" ");
                else
                    Console.Write("=");
            }
            Console.WriteLine("\n");
        }

        public void DisplayLoginMenu()
        {
            bool counter = true;
            
          try 
            {
                
                while (counter) 
                {
                    Console.Clear();
                    title();
                    Console.WriteLine("\nOption 1: Login\nOption 2: Signup\nOption 3: Guest\nOption 4: Exit");
                    Console.Write("\nChoose a Option : ");

                    int choice=int.Parse(Console.ReadLine());
                   
                    switch (choice)
                    {
                            case 1:
                                LoginPage();
                                counter = true;
                                break;
                            case 2:
                                SignUPPage();
                                counter = true;
                                break;
                            case 3:
                                MainMenu  Menu= new MainMenu();
                                Menu.GuestMenu();
                                counter = true;
                                break;
                            case 4:
                                Console.WriteLine("Click Enter to Close.");
                                counter = false;
                                break;
                            default: 
                                Console.WriteLine("Please Choose the Correct Option.");
                                counter = true;
                                break;
                    }
                }
            }
          catch (Exception ex) 
            {
                Console.WriteLine("Please Provide a Numeric Value.");
                Console.WriteLine(ex.Message); 
            }
            Console.ReadLine();
        }

        private void LoginPage()
        {
            Console.Clear ();
            title();
            UserValidation userValidation = new UserValidation();
            Console.Write("\nUser Name : ");
            userName=Console.ReadLine();
            Console.Write("\nPassword : ");
            password= Console.ReadLine();
            userValidation.UsrValidation(userName, password);
        }
        private void SignUPPage()
        {
            Console.Clear();
            title();
            User signUpUser = new User();
            Console.Write("\nName : ");
            signUpUser.Name = Console.ReadLine();
            Console.Write("\nMobile Number : ");
            signUpUser.MobileNumber = int.Parse(Console.ReadLine());
            Console.Write("\nUser Name : ");
            signUpUser.Username = Console.ReadLine();
            Console.Write("\nPassword : ");
            signUpUser.Password = Console.ReadLine();
        }
    
    }
}
