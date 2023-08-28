using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.interfaces;
using Task_Manager.services;
using Task_Manager.Enums;
using Task_Manager.Models;

namespace Task_Manager.services
{
    public class Admin : User
    {
        public Admin() : base()
        {
            UserType = UserType.Admin;
        }

        // ADMIN METHODS

        public Task<ResponseService> CreateProject(Project project)
        {
            throw new NotImplementedException();
            // Logic to create a new project
        }

        public Task<ResponseService> UpdateProject(Project project)
        {
            throw new NotImplementedException();
            // Logic to update a project
        }

        public Task<ResponseService> DeleteProject(int projectId)
        {
            throw new NotImplementedException();
            // Logic to delete a project
        }

        public Task<ResponseService> CreateTask(Project project, Tasks task)
        {
            throw new NotImplementedException();
            // Logic to create a task under a project
        }

        public Task<ResponseService> UpdateTask(Tasks task)
        {
            throw new NotImplementedException();
            // Logic to update a task
        }

        public Task<ResponseService> DeleteTask(Tasks task)
        {
            throw new NotImplementedException();
            // Logic to delete a task
        }
    }
}

