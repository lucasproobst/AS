using Microsoft.EntityFrameworkCore;
using API_AP2_POO.Models;

namespace API_AP2_POO.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<People> People { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
