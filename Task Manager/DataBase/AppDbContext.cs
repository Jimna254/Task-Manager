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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Tasks>().ToTable("Tasks");
            modelBuilder.Entity<Models.User>().ToTable("Users");
            modelBuilder.Entity<Models.Admin>().ToTable("Admins");
            modelBuilder.Entity<Models.Project>().ToTable("Projects");
        }
        public DbSet<Models.Admin> Admins { get; set; } = null!;
        public DbSet<Models.User> Users { get; set; }  = null!;
        public DbSet<Models.Project> Projects { get; set; } = null!;
        public DbSet<Models.Tasks> Tasks { get; set; } = null!;

    }
}
