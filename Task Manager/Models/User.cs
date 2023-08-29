using System;
using System.Collections.Generic;
using System.ComponentModel;

using Task_Manager.DataBase;
using Task_Manager.interfaces;
using Task_Manager.services;
using System.Threading.Tasks;
using Task_Manager.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Models
{
    public class User : IuserActions
    {
        public enum UserType
        {
            Admin,
            User
        }
        [Key]
        public int Userid { get; set; } 
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
                var user = new User
                {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    IsAdmin = userType == UserType.Admin
                };

                var db = new AppDbContext();
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
        public async Task<ResponseService> Login(string userName, string password, string email,UserType userType)
        {
            try
            {
                var db = new AppDbContext();
                var validation = new ValidationScheme();
                var isUserValid = validation.ValidateAdminInDatabase(userName, password);

                if (!isUserValid)
                {
                    return new ResponseService { Message = "You are not currently registered in our system. Please register first." };
                }

                await Login(userName, password, email, userType);
                return new ResponseService { Message = "Login Successful" };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }
        }

        // USER LOGOUT
        public async Task<ResponseService> Logout()
        {
            try
            {
                var db = new AppDbContext();
                var user = new User();
                await user.Logout();
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                var response = new ResponseService { Message = "User Logged out successfully" };
                return response;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }
        }
    }
}
