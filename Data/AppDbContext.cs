using Microsoft.EntityFrameworkCore;
using PracticeNET.Models;

namespace PracticeNET.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Team> Teams { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
