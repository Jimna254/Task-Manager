using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Helpers;
using Task_Manager.Models;

namespace Task_Manager.services
{
    public class UserMenu
    {
        public static void MenuOptions()
        {
            Console.WriteLine("Welcome to Taskit Task Management System");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("====================================");
            Console.WriteLine("Press any Key to continue");
            Console.ReadKey();
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine("====================================");
            var UserOptions = Console.ReadLine();
            switch (UserOptions)
            {
                case "1":
                    Console.WriteLine("Are you signing up as an Admin or User?");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. User");
                    var userRole = Console.ReadLine();
                    switch (userRole)
                    {
                        case "1":
                            Console.WriteLine("Please enter your username");
                            var userName = Console.ReadLine();
                            Console.WriteLine("Please enter your password");
                            var password = Console.ReadLine();
                            Console.WriteLine("Please enter your email");
                            var email = Console.ReadLine();

                            // validate user input using the validation service
                            var validation = new ValidationScheme();
                            validation.validateInput(userName, password);
                            // create an admin
                            var admin = new Admin();
                            admin.Register(userName, password, email, User.UserType.Admin);
                           
                            break;
                        case "2":
                            Console.WriteLine("Please enter your username");
                            var userName2 = Console.ReadLine();
                            Console.WriteLine("Please enter your password");
                            var password2 = Console.ReadLine();
                            Console.WriteLine("Please enter your email");
                            var email2 = Console.ReadLine();
                            var validation2 = new ValidationScheme();
                            validation2.validateInput(userName2, password2);
                            var user2 = new User();
                            user2.Register(userName2, password2, email2, User.UserType.User);
                            break;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter your username");
                    var userName1 = Console.ReadLine();
                    Console.WriteLine("Please enter your password");
                    var password1 = Console.ReadLine();
                    Console.WriteLine("Please enter your email");
                    var email1 = Console.ReadLine();
                    var user1 = new User();
                    var validation1 = new ValidationScheme();
                    validation1.validateInput(userName1, password1);
                    // if  admin login as admin
                    user1.Login(userName1, password1, email1, User.UserType.Admin);
                    
                    //If user login as user
                    user1.Login(userName1, password1, email1, User.UserType.User);
                    break;
                case "3":
                    Console.WriteLine("Thank you for using TaskIt Task Management System");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            Console.WriteLine("How would  you like to continue?");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("====================================");
            Console.WriteLine("1. View Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task As Complete");
            Console.WriteLine("4. Exit");



            var UserOptions1 = Console.ReadLine();
            switch (UserOptions1)
            {
                case "1":
                    Console.WriteLine("Please enter the task id");
                    var taskId = Console.ReadLine();
                    var validation = new ValidationScheme();
                    validation.Validate(taskId);
                   var taskIds = int.TryParse(taskId, out var taskId1) ? taskId1 : 0;   
                    var task = new ProjectTasks();
                    task.ViewTask(taskIds);
                    break;
                case "2":
                    var task1 = new ProjectTasks();
                    task1.ViewAllTasks();

                    break;
                case "3":
                    Console.WriteLine("Please enter the task id");
                    var taskId2 = Console.ReadLine();
                    var validation2 = new ValidationScheme();
                    validation2.Validate(taskId2);
                    var taskIds2 = int.TryParse(taskId2, out var taskId3) ? taskId3 : 0;
                    var task2 = new ProjectTasks();
                    task2.MarkTaskAsComplete(taskIds2);
                    break;
                case "4":
                    // exit the environment 
                    Console.WriteLine("Thank you for using TaskIt Task Management System");
                    break;
                    default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
