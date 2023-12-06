using AutoMapper;
using ExamWeb.Entities;
using ExamWeb.Models;

namespace ExamWeb.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentGetModel>();
            CreateMap<DepartmentCreateModel, Department>();
            CreateMap<DepartmentUpdateModel, Department>();
            CreateMap<Employee, EmployeeGetModel>();
            CreateMap<EmployeeCreateModel, Employee>();
            CreateMap<EmployeeUpdateModel, Employee>();
        }
    }
}
