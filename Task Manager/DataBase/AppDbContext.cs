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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Models.Admin> Admins { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Project> Projects { get; set; }
        public DbSet<Models.Tasks> Tasks { get; set; }

    }
}
