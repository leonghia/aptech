using SchoolMgt.Models;
using SchoolMgt.Repository;

namespace SchoolMgt.UnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<Lab> LabRepository { get; }
    IGenericRepository<Student> StudentRepository { get; }
    IGenericRepository<Teacher> TeacherRepository { get; }
    IGenericRepository<Subject> SubjectRepository { get; }
    Task Save();
}
