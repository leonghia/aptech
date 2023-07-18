using AutoMapper;
using SchoolMgt.DTOs.LabDTO;
using SchoolMgt.DTOs.StudentDTO;
using SchoolMgt.DTOs.SubjectDTO;
using SchoolMgt.DTOs.TeacherDTO;
using SchoolMgt.Models;

namespace SchoolMgt;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Mapper for Lab
        CreateMap<Lab, GetLabDTO>();
        CreateMap<AddLabDTO, Lab>();
        CreateMap<UpdateLabDTO, Lab>();

        // Mapper for Student
        CreateMap<Student, GetStudentDTO>();
        CreateMap<AddStudentDTO, Student>();
        CreateMap<UpdateStudentDTO, Student>();

        // Mapper for Teacher
        CreateMap<Teacher, GetTeacherDTO>();
        CreateMap<AddTeacherDTO, Teacher>();
        CreateMap<UpdateTeacherDTO, Teacher>();

        // Mapper for Subject
        CreateMap<Subject, GetSubjectDTO>();
        CreateMap<AddSubjectDTO, Subject>();
        CreateMap<UpdateSubjectDTO, Subject>();
    }
}
