using CarManagementServiceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CarManagementServiceProject.DataAccessLayer
{
    public class CabServiceDbContext:DbContext
    {
        public CabServiceDbContext(DbContextOptions<CabServiceDbContext> options): base(options)
        {

        }
        public DbSet <RegisteredEmployee> RegisteredEmployees { get; set; }
        public DbSet <AssignedDriverAndCab> AssignedDriverAndCabs { get; set; }
        public DbSet<Cab> CabsTable { get; set; }
        public DbSet<Driver> DriversTable { get; set; }
        public DbSet<EmployeePickUpDetails> EmployeePickUpDetailsTable { get; set; }
        public DbSet<EmployeeDropDetails> EmployeeDropDetailsTable { get; set; }

    }
}
