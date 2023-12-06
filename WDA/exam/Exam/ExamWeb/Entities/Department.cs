using System.ComponentModel.DataAnnotations;

namespace ExamWeb.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public required string DepartmentName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public required string DepartmentCode { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 1)]
        public required string Location { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
