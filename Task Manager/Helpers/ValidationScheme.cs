using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task_Manager.DataBase;
using Task_Manager.Models;
using static Task_Manager.Models.User;

namespace Task_Manager.Helpers
{
    public class ValidationScheme
    {
        private readonly AppDbContext dbContext = new AppDbContext();



        public bool validateInput(string Password, string UserName)
        {
            if (String.IsNullOrWhiteSpace(UserName) || String.IsNullOrWhiteSpace(Password))
            {
                Console.WriteLine("Username or Password cannot be empty");
                return false;
            }

            return true;
        }

        public bool Validate(string UserInput)
        {
            if (String.IsNullOrWhiteSpace(UserInput))
            {
                Console.WriteLine("Your choice cannot be empty");
                return false;
            }

            return true;
        }

        public bool ValidateUserInDatabase(string UserName, string Password)
        {
            try
            {
                var admin = dbContext.Set<User>().Where(u => u.UserName == UserName && u.Password == Password&&u.IsAdmin==false).FirstOrDefault();
                if (admin != null)
                {
                    // Admin exists
                    Console.WriteLine($"You have successfully signed in as {UserName}");
                    return false;
                }
                // User exists but is not an admin
                Console.WriteLine("Please TRY Again");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public bool ValidateAdminInDatabase(string UserName, string Password)
        {
            try
            {
                var admin = dbContext.Set<Admin>().Where(u => u.UserName == UserName && u.Password == Password && u.IsAdmin ==true).FirstOrDefault();
                if (admin != null)
                {
                    // Admin exists
                    Console.WriteLine("You have successfully signed in as an Admin");
                    return true;

                }

                // User exists but is not an admin
                Console.WriteLine($"You have successfully signed in as {UserName}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }






    }
}