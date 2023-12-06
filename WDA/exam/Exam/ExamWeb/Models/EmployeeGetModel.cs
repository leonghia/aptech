namespace ExamWeb.Models
{
    public class EmployeeGetModel
    {
        public int Id { get; set; }

        public required string EmployeeName { get; set; }

        
        public required string EmployeeCode { get; set; }

        
        public required int Rank { get; set; }

        public required DepartmentGetModel Department { get; set; }
    }
}
