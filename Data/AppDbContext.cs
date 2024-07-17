using CustomerService.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
