using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.services
{
    public static class ProjectService
    {
        private static List<Project> projects = new List<Project>();

        public static void AddProject(Project project)
        {
            projects.Add(project);
        }

        public static void UpdateProject(Project updatedProject)
        {
            Project? projectToUpdate = projects.Find(p => p.ProjectId == updatedProject.ProjectId);

            if (projectToUpdate != null)
            {
                // Update project properties as needed
                projectToUpdate.Title = updatedProject.Title;
                

                Console.WriteLine("Project updated successfully.");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }

        public static void DeleteProject(int projectId)
        {
            Project? projectToDelete = projects.Find(p => p.ProjectId == projectId);

            if (projectToDelete != null)
            {
                projects.Remove(projectToDelete);

                // Simulate removing tasks associated with the project
                TaskService.tasks.RemoveAll(t => t.ProjectId == projectId);

                Console.WriteLine("Project deleted successfully.");
            }
            else
            {
                Console.WriteLine("Project not found.");
            }
        }
    }
}
