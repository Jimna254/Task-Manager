using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Task_Manager.DataBase;
using Task_Manager.interfaces;
using Task_Manager.services;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class User : IuserActions
    {
        public enum UserType
        {
            Admin,
            User
        }

        public string UserName { get; set; } = string.Empty;

        [PasswordPropertyText(true)]
        public string Password { get; set; } = "User";

        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;

        public User()
        {
        }

        // USER METHODS 
        // USER REGISTER
        public async Task<ResponseService> Register(string userName, string password, string email, UserType userType)
        {
            try
            {
                var user = new User();
                var db = new AppDbContext();
                await user.Register(userName, password, email, userType);
                db.Users.Add(user);
                await db.SaveChangesAsync();
                var response = new ResponseService { Message = "User Created successfully" };
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }
        }


        // USER LOGIN
        public async Task<ResponseService> Login(string userName, string password, string email, UserType userType)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = userType == UserType.Admin;

            if (!IsAdmin)
            {
                var user = new User();
                await user.Login(userName, password, email, UserType.User);
            }
            else
            {
                var admin = new User();
                await admin.Login(userName, password, email, UserType.Admin);
            }

            return new ResponseService();
        }

        // USER LOGOUT
        public async Task<ResponseService> Logout()
        {
            Console.WriteLine("You have been logged out");
            return new ResponseService();
        }
    }
}
