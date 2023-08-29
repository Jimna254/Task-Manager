using System;
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
    public class Tasks
    {
        // BEGIN THE TASK PROPERTIES
        [Key]
        public int TaskId { get; set; }


        public Project? Project { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }


        public string? Description { get; set; }

        public string? Type { get; set; }

        public TaskPriority taskPriority { get; set; } = TaskPriority.Medium;

        public TaskStatus taskStatus { get; set; } = TaskStatus.UnAssigned;

        public DateTime? DueDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public User? AssignedTo { get; set; }


    }
}