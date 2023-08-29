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
            optionsBuilder.UseSqlServer(@"Server=localhost; Database= TaskManagerDB; Trusted_Connection=True; TrustServerCertificate=True");
            optionsBuilder.LogTo(Console.WriteLine);
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }


        public DbSet<Models.Admin>? Admins { get; set; } 
        public DbSet<Models.User>? Users { get; set; } 
        public DbSet<Models.Project>? Projects { get; set; } 
        public DbSet<Models.ProjectTasks>? ProjectTasks { get; set; }

    }
}
