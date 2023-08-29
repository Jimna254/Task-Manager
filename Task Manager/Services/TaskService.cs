using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.services
{
    public static class TaskService
    {
        public static List<Tasks> tasks = new List<Tasks>();

        public static void AddTask(Tasks task)
        {
            tasks.Add(task);
        }

        public static void UpdateTask(Tasks updatedTask)
        {
            Tasks taskToUpdate = tasks.Find(t => t.TaskId == updatedTask.TaskId);

            if (taskToUpdate != null)
            {
                // Update task properties as needed
                taskToUpdate.Title = updatedTask.Title;
                // Update other task properties

                Console.WriteLine("Task updated successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public static void DeleteTask(Tasks task)
        {
            Tasks taskToDelete = tasks.FirstOrDefault(t => t.TaskId == task.TaskId);

            if (taskToDelete != null)
            {
                tasks.Remove(taskToDelete);
                Console.WriteLine("Task deleted successfully.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
    }
}
