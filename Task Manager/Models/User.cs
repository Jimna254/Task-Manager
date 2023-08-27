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

        [PasswordPropertyText(true)]
        public string Password { get; set; } = "User";

        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;



        public User()
        {

        }
 // USER METHODS 
        public void Login( string userName, string password , string email, bool isAdmin)
        {
            this.UserName = userName;
            this.Password = password;
            this.Email = email;
            this.IsAdmin = isAdmin;
        }
        

       

        public async Task ViewTask( string TaskId){
            try {
                var task = await DbContext.Tasks.FindAsync(TaskId);
                 return task;
            }catch {

            }
        }

        public void MarkTaskAsComplete(){

        }



    }
}
