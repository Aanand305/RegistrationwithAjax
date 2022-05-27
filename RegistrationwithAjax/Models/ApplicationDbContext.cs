using Microsoft.EntityFrameworkCore;

namespace RegistrationwithAjax.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
    }
}
