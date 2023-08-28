using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Task_Manager.DataBase;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public enum UserType
    {
        Admin,
        User
    }
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; } = string.Empty;

        [PasswordPropertyText(true)] public string Password { get; set; } = "User";

        public string Email { get; set; } = string.Empty;

        public UserType userType { get; set; } = UserType.User;

        // USER METHODS 


        //USER REGISTER
        public void Register()
        {
            // Logic for user registration
            var User = new User
            {
                UserName = this.UserName,
                Password = this.Password,
                Email = this.Email,
                userType = this.userType
            };

            using (var dbContext = new AppDbContext())
            {
                dbContext.Users.Add(User);
                dbContext.SaveChanges();
            }
        }

        // user login

        public void Login(int userID, string userName, string password, string email, UserType userType)
        {
            // Logic for user login
            using (var dbContext = new AppDbContext())
            {
                var user = dbContext.Users.Find(userID);
                if (user != null)
                {
                    UserName = userName;
                    Password = password;
                    Email = email;
                    this.userType = userType;
                }
            }
        }


        // user logout

        public void Logout()
        {
            // Logic for user logout
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Email = string.Empty;
            this.userType = UserType.User;
        }

     
    }


}


