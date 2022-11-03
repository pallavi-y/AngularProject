using Microsoft.EntityFrameworkCore;
using ProjectCompanyServiceAPI.Models;

namespace ProjectCompanyServiceAPI.DataAccessLayer
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> EmployeesTable { get; set; }
    }
}
