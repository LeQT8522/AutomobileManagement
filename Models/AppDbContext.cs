using Microsoft.EntityFrameworkCore;
using System;

namespace AutomobileManagement.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public string DbPath { get; }

        public AppDbContext()
        {
            var appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = System.IO.Path.Join(appDataFolderPath, "blogging.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={DbPath}");
        }
    }
}