using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Lab15.Models;

namespace Lab15
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Producto> Productos{ get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Employee.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
