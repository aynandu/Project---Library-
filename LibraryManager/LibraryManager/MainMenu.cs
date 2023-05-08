using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class MainMenu
    {
        Login login=new Login();
        public void DisplayMainMenu() // just started 
        {
           
                Console.Clear();           
                login.title();
        }

        public void AdminMenu()
        {
            try
            {               
                Console.WriteLine("Option 1: View Book\nOption 2: Add Stock\nOption 3: My Book \nOption 4: Extent the Period" +
                    "\nOption 5: View Queue \nOption 6: Search \nOption 7: Sort \nOption 8: Delete User \nOption 9: Exit");
                Console.Write("\nChoose a Option : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BookInfo bookInfo = new BookInfo();
                        bookInfo.DisplayBookInfo();
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
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

                        break;
                    case 9:
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
        public void LocalMenu()
        {
            try
            {                
                Console.WriteLine("Option 1: View Book\nOption 2: My Cart\nOption 3: Choose Book \nOption 4: Extent the Period" +
                    "\nOption 5: Search \nOption 6: Sort \nOption 7: Exit");
                Console.Write("\nChoose a Option : ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BookInfo bookInfo = new BookInfo();
                        bookInfo.DisplayBookInfo();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:
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
                        BookInfo bookInfo = new BookInfo();
                        bookInfo.DisplayBookInfo();
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
