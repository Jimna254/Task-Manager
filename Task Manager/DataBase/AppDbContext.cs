using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Manager.Models;

namespace Task_Manager.DataBase
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-KDHQCIN; Database= TaskManagerDB; Trusted_Connection=True; TrustServerCertificate=True; User Id = sa;");
        }

       
       
        public DbSet<Models.User> Users { get; set; }  = null!;
        public DbSet<Models.Project> Projects { get; set; } = null!;
        public DbSet<Models.Tasks> Tasks { get; set; } = null!;

    }
}
