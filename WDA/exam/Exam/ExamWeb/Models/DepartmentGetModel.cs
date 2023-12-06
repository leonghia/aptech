namespace ExamWeb.Models
{
    public class DepartmentGetModel
    {
        public int Id { get; set; }

        public required string DepartmentName { get; set; }

        public required string DepartmentCode { get; set; }

        public required string Location { get; set; }

    }
}
