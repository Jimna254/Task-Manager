using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public enum UserType{
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



        
        

    
        

    }
}
        

