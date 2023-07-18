using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMgt.DTOs.SubjectDTO;
using SchoolMgt.Models;
using SchoolMgt.UnitOfWork;

namespace SchoolMgt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerGeneric<Subject>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubjectController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetSubjectDTO>>>> GetAll()
    {
        return await base.GetAll<GetSubjectDTO>();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetSubjectDTO>>> GetSingle(int id)
    {
        return await base.GetSingle<GetSubjectDTO>(id);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> Add(AddSubjectDTO subject)
    {
        return await base.Add<AddSubjectDTO>(subject);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Update(int id, UpdateSubjectDTO subject)
    {
        return await base.Update<UpdateSubjectDTO>(id, subject);
    }

    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        return await base.Delete(id);
    }
}
