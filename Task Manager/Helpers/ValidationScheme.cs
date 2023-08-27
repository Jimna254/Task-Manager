using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Helpers
{
    public class ValidationScheme
    {
        public  bool validateInput(string username, string password)
        {
            if(String.IsNullOrEmpty(username)|| String.IsNullOrEmpty(password)){
                Console.WriteLine("Username or Password cannot be empty");
                return false;
            }
            return true;
        }

        public bool ValidateUserInDatabase(string UserName, string Password)
        {
            var user = DbContext.User.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault();
            if (user == null)
            {
                Console.WriteLine("User does not exist");
                return false;
            }
            return true;
        }

        public bool ValidateAdminInDatabase(string UserName, string Password)
        {
            var admin = DbContext.Admin.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault();
            if (admin == null)
            {
                Console.WriteLine("Admin does not exist");
                return false;
            }
            return true;
        }

    }
}