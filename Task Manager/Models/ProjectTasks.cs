
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Task_Manager.DataBase;
using Task_Manager.Enums;
using Task_Manager.interfaces;
using Task_Manager.services;
using TaskStatus = Task_Manager.Enums.TaskStatus;

namespace Task_Manager.Models
{
    public class ProjectTasks : ITaskInterface
    {
        // BEGIN THE TASK PROPERTIES
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.Low;

        public TaskStatus Status { get; set; } = TaskStatus.UnAssigned;


        public bool? IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public User? AssignedTo { get; set; }


        // BEGIN THE TASK METHODS

        public Task<ResponseService> UpdateTask(ProjectTasks task)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> DeleteTask(ProjectTasks task)
        {
            throw new NotImplementedException();
        }

        public async  Task<ResponseService> CreateTask(int ProjectId)
        {
            try
            {
                var db = new AppDbContext();
                var project = await db.Projects.Where(x => x.Id == ProjectId).FirstOrDefaultAsync();
                var task = new ProjectTasks();
                var response = await db.ProjectTasks.AddAsync(task);
                await db.SaveChangesAsync();
                return new ResponseService { Message = "Task Created Successfully" };

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }
        }

        public async Task<ResponseService> AssignTask(int TaskId, int UserId)
        {
            try
            {
                var db = new AppDbContext();
                var task = await db.ProjectTasks.Where(x => x.Id == TaskId).FirstOrDefaultAsync();
                var user = await db.Users.FindAsync(UserId);
                var response = await db.ProjectTasks.AddAsync(task);
                task.AssignedTo = user;
                db.SaveChanges();
                return new ResponseService { Message = "Task Assigned Successfully" };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }
        }

        public async Task<List<ProjectTasks>> ViewTask(int TaskId)
        {
            try
            {
                var db = new AppDbContext();
               var response= await db.ProjectTasks.Where(x => x.Id == TaskId).ToListAsync();
               return response;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task<List<ProjectTasks>> ViewAllTasks()
        {
            try
            {
                var db = new AppDbContext();
                var response =await  db.ProjectTasks.ToListAsync();
                return response;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public async Task<ResponseService> MarkTaskAsComplete(int TaskId)
        {
            try
            {
                var db = new AppDbContext();
                var task =  await db.ProjectTasks.Where(x => x.Id == TaskId).FirstOrDefaultAsync();
                task.IsCompleted = true;
                db.SaveChanges();
                return new ResponseService { Message = "Task Completed" };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ResponseService();
            }

         
        }
    }
}
