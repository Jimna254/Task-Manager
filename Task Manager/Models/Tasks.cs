﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Enums;
using Task_Manager.interfaces;
using Task_Manager.services;
using TaskStatus = Task_Manager.Enums.TaskStatus;

namespace Task_Manager.Models
{
    public class Tasks: ITaskInterface
    {
        // BEGIN THE TASK PROPERTIES
        [Key]
        public int TaskId { get; set; }


       public Project? Project { get; set; }
        public string? Title { get; set; }


        public string? Description { get; set; }

        public string? Type { get; set; }

        public TaskPriority taskPriority { get; set; } = TaskPriority.Medium;

        public TaskStatus taskStatus { get; set; } = TaskStatus.UnAssigned;

        public DateTime? DueDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public User? AssignedTo { get; set; }


// BEGIN THE TASK METHODS
       

        public Task<ResponseService> AssignTask(User user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> UpdateTask(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> DeleteTask(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> CreateTask(Project project, Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseService>> ViewTask(Tasks task)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseService>> ViewAllTasks()
        {
            throw new NotImplementedException();
        }
        public Task<ResponseService> MarkTaskAsComplete(Tasks task)
        {
            throw new NotImplementedException();
        }

        internal static Tasks FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
