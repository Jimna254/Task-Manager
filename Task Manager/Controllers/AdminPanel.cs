using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Manager.Helpers;

namespace Task_Manager.services
{
    public class AdminPanel
    {
        public void ShowAdminPanel()
        {
            Console.WriteLine( "Welcome to TaskIT Admin Panel ");
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
            Console.WriteLine("5.Logout");

            var AdminOptions = Console.ReadLine();  
            var validation = new ValidationScheme();
            validation.validateInput(AdminOptions)

        }


    }
}