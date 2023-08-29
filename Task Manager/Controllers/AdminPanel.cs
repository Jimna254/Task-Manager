using System;
using System.Threading.Tasks;
using Task_Manager.Enums;
using Task_Manager.Helpers;
using Task_Manager.interfaces;
using Task_Manager.Models;
using Task_Manager.services;



namespace Task_Manager.services
{
    public class AdminPanel
    {
        private ValidationScheme validation = new ValidationScheme();
        private readonly Admin _admin;
        private readonly ITaskInterface _taskInterface;
        private readonly IuserActions _userActions;





        public AdminPanel(Admin admin)
        {
            _admin = admin;
        }







        public async Task ShowAdminPanel()
        {
            while (true)
            {
                Console.WriteLine("Welcome to TaskIT Admin Panel ");
                Console.WriteLine(" ++++++++++++++++++++++++++++++++++");
                Console.WriteLine("====================================");
                Console.WriteLine("Press any Key to continue");
                Console.ReadKey();
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Create A Project ");
                Console.WriteLine("2. View Available Projects");
                Console.WriteLine("3. Update Project");
                Console.WriteLine("4. Create Tasks");
                Console.WriteLine("5. Update Task");
                Console.WriteLine("6. Delete Task");
                Console.WriteLine("7. Assign Task to User");
                Console.WriteLine("8. Delete User");
                Console.WriteLine("0. Logout");



                var adminOptions = Console.ReadLine();
                validation.Validate(adminOptions);



                if (int.TryParse(adminOptions, out var optionNumber))
                {
                    await ProcessAdminOption(optionNumber);
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }
        }



        private async Task ProcessAdminOption(int optionNumber)
        {
            switch (optionNumber)
            {
                case 1:
                    var project = new Project();
                    var admin = new Admin();
                    var createProjectResponse = await _admin.CreateProject(project);
                    Console.WriteLine(createProjectResponse.Message);
                    break;
                case 2:
                    await _admin.GetAllProjects();
                    break;
                case 3:
                    var updatedproject = new Project();
                    var updateProjectResponse = await _admin.UpdateProject(updatedproject);
                    Console.WriteLine(updateProjectResponse.Message);
                    break;

                case 4:
                    var createTask = new ProjectTasks();
                    var selectedProject = new Project(); // Instantiate the selected project
                    var createTaskResponse = await _admin.CreateTask(selectedProject, createTask);
                    Console.WriteLine(createTaskResponse.Message);
                    break;



                case 5:
                    var updateTask = new ProjectTasks();

                    var updateTaskResponse = await _admin.UpdateTask(updateTask);
                    Console.WriteLine(updateTaskResponse.Message);
                    break;



                case 6:
                    var deleteTask = new ProjectTasks();



                    var deleteTaskResponse = await _admin.DeleteTask(deleteTask);
                    Console.WriteLine(deleteTaskResponse.Message);
                    break;
                case 7:
                    await _admin.AssignTaskToUser();



                    break;
                case 8:
                    await _admin.DeleteUser();
                    break;
                case 0:
                    var user = new User();
                    user.Logout();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}
