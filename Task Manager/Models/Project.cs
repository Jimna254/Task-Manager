
using System.ComponentModel.DataAnnotations;
using Task_Manager.interfaces;
using Task_Manager.services;

namespace Task_Manager.Models
{
    public class Project: IProject
    {
        [Key]
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public List<Tasks> Tasks { get; set; } = new List<Tasks>();

        public User? User { get; set; }

        

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

        public Task<List<ResponseService>> AssignTask(int Taskid)
        {
            throw new NotImplementedException();
        }
        public Task<List<ResponseService>> ViewCompletedProjects(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
