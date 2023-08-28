using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Models;
using Task_Manager.services;

namespace Task_Manager.interfaces
{
    public interface IProject
    {
        public Task<ResponseService> CreateProject(Project project);

        public Task<ResponseService> UpdateProject(Project project);

        public Task<ResponseService> DeleteProject(int id);

        public Task<List<ResponseService>> GetProject(int id);

        public Task<List<ResponseService>> GetAllProjects();

        public Task<List<ResponseService>> AssignTask(int Taskid);  //Assign a task to a project

        public Task<List<ResponseService>> ViewCompletedProjects(Project project);

    }
}
