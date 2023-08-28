using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Helpers;
using Task_Manager.Models;

namespace Task_Manager.services
{
    public class AdminPanel
    {
        private ValidationScheme validation = new();

        public void ShowAdminPanel()
        {
            Console.WriteLine("Welcome to TaskIT Admin Panel ");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++");
            Console.WriteLine("====================================");
            Console.WriteLine("Press any Key to continue");
            Console.ReadKey();
            Console.WriteLine("Please select an option");
            Console.WriteLine("1.Create A Project ");
            Console.WriteLine("2.View Available Projects");
            Console.WriteLine("3.Assign A Task");
            Console.WriteLine("3.View Assigned Projects");
            Console.WriteLine("4.View Completed Projects");
            Console.WriteLine();
            Console.WriteLine("5.Logout");

            var AdminOptions = Console.ReadLine();
            var validation = new ValidationScheme();
            validation.Validate(AdminOptions);
        }
        public async Task CheckUserOptions(string AdminOptions, int Taskid)
        {
            var project = new Project();
            switch (AdminOptions)
            {
                case "1":
                    await project.CreateProject(project);
                    break;
                case "2":
                    await project.GetAllProjects();
                    break;
                case "3":
                    await project.AssignTask(Taskid);
                    break;
                case "4":
                    Console.WriteLine("Enter Project Id");
                    var projectId = Console.ReadLine();
                    await project.GetProject(int.TryParse(projectId, out var projectsId) ? projectsId : 0);
                   
                    break;
                case "5":
                    await project.ViewCompletedProjects(project);
                    break;
                case "6":
                    var User = new User();
                    User.Logout();
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
        }
    }

