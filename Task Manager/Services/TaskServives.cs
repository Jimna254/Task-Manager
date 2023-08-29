using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;



namespace Task_Manager.services
{
    public static class TaskService
    {
        public static List<ProjectTasks> tasks = new List<ProjectTasks>();



        public static void AddTask(ProjectTasks task)
        {
            tasks.Add(task);
        }



        public static void UpdateTask(ProjectTasks updatedTask)
        {
            ProjectTasks taskToUpdate = tasks.Find(t => t.Id== updatedTask.Id);



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



        public static void DeleteTask(ProjectTasks task)
        {
            ProjectTasks taskToDelete = tasks.FirstOrDefault(t => t.Id == task.Id);



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