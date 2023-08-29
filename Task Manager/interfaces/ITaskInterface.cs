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
        
        public Task<ResponseService> AssignTask(int TaskId, int UserId);

        public Task<ResponseService> UpdateTask(Models.ProjectTasks task);

        public Task<ResponseService> DeleteTask(Models. ProjectTasks tasks);

        public Task<ResponseService> CreateTask(int projectId);

        public Task<List<ProjectTasks>> ViewTask(int taskId);

        public Task<List<ProjectTasks>> ViewAllTasks();

        public Task<ResponseService> MarkTaskAsComplete(int TaskId);

        
    }
}