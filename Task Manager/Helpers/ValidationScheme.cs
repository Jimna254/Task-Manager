using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task_Manager.DataBase;
using Task_Manager.Models;

namespace Task_Manager.Helpers
{
    public class ValidationScheme
    {
        private readonly AppDbContext dbContext= new AppDbContext();



        public bool validateInput(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
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
                var user = dbContext.Set<User>().Where(u => u.UserName == UserName && u.Password == Password)
                    .FirstOrDefault();
                if (user == null)
                {
                    Console.WriteLine("User does not exist");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return true;
        }

        public bool ValidateAdminInDatabase(string UserName, string Password)
        {
            try
            {
                var admin = dbContext.Set<Admin>().Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefault();
                if (admin == null)
                {
                    Console.WriteLine("Admin does not exist");
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return true;

        }
    }
}