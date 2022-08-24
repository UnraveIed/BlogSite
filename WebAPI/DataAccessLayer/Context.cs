using Microsoft.EntityFrameworkCore;

namespace WebAPI.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=BATU\SQLEXPRESS; database=CoreBlogApiDb; integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
