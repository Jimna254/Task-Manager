
using System.ComponentModel.DataAnnotations.Schema;
using Task_Manager.interfaces;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public class Project: IProject
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public List<ProjectTasks> Tasks { get; set; } = new List<ProjectTasks>();

        public Task<ResponseService> CreateProject(Project project)
        {
            throw new NotImplementedException();
            //logic to create project
        }

        public Task<ResponseService> DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseService>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

       public Task<List<ResponseService>> GetProject(int id)
        {
            throw new NotImplementedException();
        } 

        public Task<ResponseService> UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponseService>> AssignTask(int projectTaskId)
        {
            throw new NotImplementedException();
        }
        public Task<List<ResponseService>> ViewCompletedProjects(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
