using ExamWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamWeb.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = 1,
                    EmployeeName = "La Trong Nghia",
                    EmployeeCode = "E01",
                    Rank = 1,
                    DepartmentId = 4
                }
                );
        }
    }
}
