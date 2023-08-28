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
            Console.WriteLine( "Welcome to Taskit Task Management System");
            Console.WriteLine(" ++++++++++++++++++++++++++++++++++");
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
                            admin.Login(userName, password, email, true);
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
                            user2.Login(userName2, password2, email2, false);
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
                    var user1 = new User();
                    var validation1 = new ValidationScheme();
                    validation1.validateInput(userName1, password1);

                    user1.Login(userName1, password1, null, false);
                    break;
                case "3":
                    Console.WriteLine("Thank you for using TaskIt Task Management System");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }

            // 
            Console.WriteLine("1. View Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Mark Task As Complete");
            Console.WriteLine("4. Exit");


        }


        
    }
}