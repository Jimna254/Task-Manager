using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Models;
using Task_Manager.services;



namespace Task_Manager.interfaces
{
    public interface IAdminRoles
    {
        public Task<ResponseService> CreateProject(Project project);
        public Task<ResponseService> UpdateProject(Project project);



        public Task<ResponseService> DeleteProject(Project project);



        public Task<ResponseService> DeleteUser(User user);



        public Task<ResponseService> UpdateUser(User user);



        public Task<ResponseService> CreateTask(ProjectTasks tasks);



        public Task<ResponseService> UpdateTask(ProjectTasks tasks);



        public Task<ResponseService> DeleteTask(ProjectTasks tasks);



        public Task<ResponseService> AssignTask(User user);



    }
}