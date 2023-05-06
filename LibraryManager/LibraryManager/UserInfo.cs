using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
     class UserInfo
    {
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
    }
}
