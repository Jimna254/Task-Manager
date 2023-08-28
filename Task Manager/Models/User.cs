using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Enums;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        [PasswordPropertyText(true)] public string Password { get; set; } = "User";

        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;

        public UserType UserType { get; set; }

        public User()
        {

        }

        // USER METHODS 


        //USER REGISTER
        public void Register(string userName, string password, string email, UserType userType)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = userType == UserType.Admin;

            if (!IsAdmin)
            {
                var user = new User();
                user.Register(userName, password, email,  UserType.User);

            }
            else
            {
                var Admin = new User();
                Admin.Register(userName, password, email, UserType.Admin);

            }
        }



        //USER LOGIN
        public void Login(string userName, string password, string email,UserType userType)
        {
            this.Password = password;
            this.Email = email;
            this.IsAdmin = userType == UserType.Admin;

            if (!IsAdmin)
            {
                var user = new User();
                user.Login(userName, password, email, UserType.User);

            }
            else
            {
                var Admin = new User();
                Admin.Login(userName, password, email, UserType.Admin);
                    
            }


        }

        public void Logout()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Email = string.Empty;
            this.IsAdmin = false;

        }
        

    }
}
        

