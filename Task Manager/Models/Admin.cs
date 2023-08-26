using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{
    public class Admin
    {
        public string UserName { get; set; } = "User";

        [PasswordPropertyText(true)]
        public string Password { get; set; } = "Admin";

    }
}
