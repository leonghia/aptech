namespace ExamWeb.Models
{
    public class EmployeeUpdateViewModel
    {
        public required EmployeeUpdateModel EmployeeUpdateModel { get; set; }
        public required IEnumerable<DepartmentGetModel> DepartmentGetModels { get; set; }
    }
}
