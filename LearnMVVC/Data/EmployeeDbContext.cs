using LearnMVVC.Models.DataModel;
using Microsoft.EntityFrameworkCore;

namespace LearnMVVC.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
