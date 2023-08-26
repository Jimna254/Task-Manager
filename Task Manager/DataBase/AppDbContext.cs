using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.DataBase
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KDHQCIN;Initial Catalog = Task-Manager;Trusted_Connection=True; TrustServerCertificate=True; User Id = sa; Password= @Stockholm01");
        }

    }
}
