using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Manager.DataBase;
using Task_Manager.Enums;
using Task_Manager.Models;



namespace Task_Manager.services
{
    public class Admin : User
    {

        private readonly AppDbContext _dbContext;



        //public Admin(AppDbContext dbContext) : base()
        //{
        //    //UserType = UserType.Admin;
        //    _dbContext = dbContext;
        //}
        // ADMIN METHODS



        public Task<ResponseService> CreateProject(Project project)
        {

            try
            {
                ProjectService.AddProject(project);



                return Task.FromResult(new ResponseService
                {
                    Message = "Project created successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }



        public Task<ResponseService> UpdateProject(Project project)
        {
            try
            {
                ProjectService.UpdateProject(project);



                return Task.FromResult(new ResponseService
                {
                    Message = "Project updated successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }



        public Task<ResponseService> DeleteProject(int projectId)
        {
            try
            {
                ProjectService.DeleteProject(projectId);



                return Task.FromResult(new ResponseService
                {
                    Message = "Project deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }



        public Task<ResponseService> CreateTask(Project project, ProjectTasks task)
        {
            try
            {
                TaskService.AddTask(task);



                return Task.FromResult(new ResponseService
                {
                    Message = "Task created successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }



        public Task<ResponseService> UpdateTask(ProjectTasks task)
        {
            try
            {
                TaskService.UpdateTask(task);



                return Task.FromResult(new ResponseService
                {
                    Message = "Task updated successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }





        public Task<ResponseService> DeleteTask(ProjectTasks task)
        {
            try
            {
                // Delete a task

                TaskService.DeleteTask(task);



                return Task.FromResult(new ResponseService
                {
                    Message = "Task deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                });
            }
        }



        public async Task<ResponseService> GetAllProjects()
        {
            try
            {
                var projects = _dbContext.Projects.ToList();



                if (projects.Any())
                {
                    Console.WriteLine("Available Projects:");
                    foreach (var project in projects)
                    {
                        Console.WriteLine($"Project ID: {project.ProjectId}, Name: {project.Title}, Tasks: {project.Tasks}, {project.User}");
                    }
                }
                else
                {
                    Console.WriteLine("No projects available.");
                }



                return new ResponseService
                {
                    Message = "Projects retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResponseService
                {
                    Message = "An error occurred: " + ex.Message
                };
            }
        }
        public async Task AssignTaskToUser()
        {
            Console.WriteLine("Enter Task ID:");
            if (int.TryParse(Console.ReadLine(), out var taskId))
            {
                var task = await _dbContext.ProjectTasks.FindAsync(taskId);
                if (task != null)
                {
                    Console.WriteLine("Enter User ID to assign the task:");
                    if (int.TryParse(Console.ReadLine(), out var userId))
                    {
                        var user = await _dbContext.Users.FindAsync(userId);
                        if (user != null)
                        {
                            task.AssignedTo = user; // Assuming 'AssignedTo' is a navigation property in the Task model
                            await _dbContext.SaveChangesAsync();
                            Console.WriteLine("Task assigned successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid User ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Task ID.");
            }
        }



        public async Task DeleteUser()
        {
            Console.WriteLine("Enter User ID to delete:");
            if (int.TryParse(Console.ReadLine(), out var userId))
            {
                var user = await _dbContext.Users.FindAsync(userId);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                    Console.WriteLine("User deleted successfully.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid User ID.");
            }
        }







    }
}