using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.services;
using static Task_Manager.Models.User;

namespace Task_Manager.interfaces
{
    public interface IuserActions
    {
        public Task<ResponseService> Register(string userName, string password, string email, UserType userType);

        public Task<ResponseService> Login(string userName, string password, string email, UserType userType);

        public Task <ResponseService>Logout();
        
    }
}