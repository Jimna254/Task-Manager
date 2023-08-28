using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;
using Task_Manager.services;

namespace Task_Manager.interfaces
{
    public interface ITaskInterface
    {
        
        public Task<ResponseService> AssignTask(User user);

        public Task<ResponseService> UpdateTask(Tasks task);

        public Task<ResponseService> DeleteTask(Tasks task);

        public Task<ResponseService> CreateTask(Project project, Tasks task);

        public Task<List<ResponseService>> ViewTask(Tasks task);

        public Task<List<ResponseService>> ViewAllTasks();

        public Task<ResponseService> MarkTaskAsComplete(Tasks task);

        
    }
}