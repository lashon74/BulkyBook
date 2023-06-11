using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {//Using Dbcontext to utilize entity frame work
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        //Telling DbContext to use the table that was created
        public DbSet<Category> Categories { get; set; }

    }
}
