using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;

        [PasswordPropertyText(true)] public string Password { get; set; } = "User";

        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;



        public User()
        {

        }

        // USER METHODS 


        //USER REGISTER
        public void Register(string userName, string password, string email, bool isAdmin)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = isAdmin;

            if (!isAdmin)
            {
                var user = new User();
                user.Register(userName, password, email, false);

            }
            else
            {
                var Admin = new User();
                Admin.Register(userName, password, email, true);

            }
        }



        //USER LOGIN
        public void Login(string userName, string password, string email, bool isAdmin)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = isAdmin;

            if (!isAdmin)
            {
                var user = new User();
                user.Login(userName, password, email, false);

            }
            else
            {
                var Admin = new User();
                Admin.Login(userName, password, email, true);
                    
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
        

