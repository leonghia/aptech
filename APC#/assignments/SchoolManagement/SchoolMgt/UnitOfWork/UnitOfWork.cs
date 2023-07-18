using SchoolMgt.Data;
using SchoolMgt.Models;
using SchoolMgt.Repository;

namespace SchoolMgt.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private IGenericRepository<Lab> _labRepository;
    private IGenericRepository<Student> _studentRepository;
    private IGenericRepository<Teacher> _teacherRepository;
    private IGenericRepository<Subject> _subjectRepository;
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    public IGenericRepository<Lab> LabRepository => _labRepository ??= new GenericRepository<Lab>(_context);

    public IGenericRepository<Student> StudentRepository => _studentRepository ??= new GenericRepository<Student>(_context);

    public IGenericRepository<Teacher> TeacherRepository => _teacherRepository ??= new GenericRepository<Teacher>(_context);

    public IGenericRepository<Subject> SubjectRepository => _subjectRepository ??= new GenericRepository<Subject>(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
