using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class User
    {
        public string UserName { get; set; } = string.Empty;

        [PasswordPropertyText(true)]
        public string Password { get; set; } = "User";



    }
}
