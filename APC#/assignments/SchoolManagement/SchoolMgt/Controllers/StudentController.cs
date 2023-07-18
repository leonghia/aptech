using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMgt.DTOs.StudentDTO;
using SchoolMgt.Models;
using SchoolMgt.UnitOfWork;

namespace SchoolMgt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerGeneric<Student>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetStudentDTO>>>> GetAll()
    {

        return await base.GetAll<GetStudentDTO>();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetStudentDTO>>> GetSingle(int id)
    {
       return await base.GetSingle<GetStudentDTO>(id);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> Add(AddStudentDTO student)
    {
        return await base.Add<AddStudentDTO>(student);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Update(int id, UpdateStudentDTO student)
    {
        return await base.Update<UpdateStudentDTO>(id, student);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        return await base.Delete(id);
    }
}
