using System.ComponentModel.DataAnnotations;

namespace ExamWeb.Models
{
    public class EmployeeUpdateModel
    {
        [Required]
        [StringLength(256, MinimumLength = 3)]
        public required string EmployeeName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public required string EmployeeCode { get; set; }

        [Required]
        public required int Rank { get; set; }

        [Required]
        public required int DepartmentId { get; set; }
    }
}
