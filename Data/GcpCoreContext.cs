using CoreGCP.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreGCP.Data
{
    public class GcpCoreContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public GcpCoreContext(DbContextOptions<GcpCoreContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.SeedEmployees(builder);
        }


        private void SeedEmployees(ModelBuilder builder)
        {
            Employee emp = new Employee()
            {
                Id = 1,
                FirstName = "Ravish",
                LastName = "Muthuswamy"
            };

            builder.Entity<Employee>().HasData(emp);
        }
    }
}
