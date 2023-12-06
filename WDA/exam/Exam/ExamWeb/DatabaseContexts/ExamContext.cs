using ExamWeb.Configurations;
using ExamWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamWeb.DatabaseContexts
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Department>(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
        }

        public DbSet<Department> Department_Tbl { get; set; }
        public DbSet<Employee> Employee_Tbl { get; set; }

        
    }
}
