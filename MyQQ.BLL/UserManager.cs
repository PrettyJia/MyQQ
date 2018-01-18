using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyQQ.Modles;
namespace MyQQ.BLL
{
    public class UserManager
    {
        public static Users Login()
        {
            MyQQ.DAL.UserService.Login();
        }
    }
}
