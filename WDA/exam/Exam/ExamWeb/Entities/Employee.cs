using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamWeb.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public required string EmployeeName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public required string EmployeeCode { get; set; }

        [Required]
        public required int Rank { get; set; }

        [ForeignKey("Department")]
        [Required]
        public required int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
