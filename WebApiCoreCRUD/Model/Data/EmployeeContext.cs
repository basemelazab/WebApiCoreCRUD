using Microsoft.EntityFrameworkCore;

namespace WebApiCoreCRUD.Model.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<tblEmployee> Employees { get; set; }
        public DbSet<tblDesignation> Designations { get; set; }
    }
}
