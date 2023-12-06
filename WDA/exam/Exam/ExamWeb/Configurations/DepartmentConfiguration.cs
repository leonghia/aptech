using ExamWeb.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamWeb.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    Id = 1,
                    DepartmentName = "Accounting",
                    DepartmentCode = "ACC",
                    Location = "Vietnam"
                },
                new Department
                {
                    Id = 2,
                    DepartmentName = "Production Management",
                    DepartmentCode = "PMGT",
                    Location = "Vietnam"
                },
                new Department
                {
                    Id = 3,
                    DepartmentName = "Human Resources",
                    DepartmentCode = "HR",
                    Location = "Vietnam"
                },
                new Department
                {
                    Id = 4,
                    DepartmentName = "Information Technology",
                    DepartmentCode = "IT",
                    Location = "Vietnam"
                }
                );
        }
    }
}
