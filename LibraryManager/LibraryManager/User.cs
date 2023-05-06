using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    class User
    {
        public LoggedInStatus status;
        public string Name { get; set; }
        public int MobileNumber { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public LoggedInStatus LoggedIN 
        {
            get
            {
                return  status;
            }
            set
            {
                status = value;
            }
        }
        public enum LoggedInStatus
        {
            admin,
            local,
            guest
        }

    }
        
    
}
