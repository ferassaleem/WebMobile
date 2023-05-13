using Microsoft.EntityFrameworkCore;
using WebMobile.Models;

namespace WebMobile.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) 
        {
            
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Operating> Operatings { get; set; }


    }
}
