using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMgt.DTOs.TeacherDTO;
using SchoolMgt.Models;
using SchoolMgt.UnitOfWork;

namespace SchoolMgt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerGeneric<Teacher>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TeacherController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetTeacherDTO>>>> GetAll()
    {
        return await base.GetAll<GetTeacherDTO>();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetTeacherDTO>>> GetSingle(int id)
    {
        return await base.GetSingle<GetTeacherDTO>(id);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> Add(AddTeacherDTO teacher)
    {
        return await base.Add<AddTeacherDTO>(teacher);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Update(int id, UpdateTeacherDTO teacher)
    {
        return await base.Update<UpdateTeacherDTO>(id, teacher);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        return await base.Delete(id);
    }
}
