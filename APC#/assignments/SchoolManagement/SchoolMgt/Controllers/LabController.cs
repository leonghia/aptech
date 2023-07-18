using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMgt.DTOs.LabDTO;
using SchoolMgt.Models;
using SchoolMgt.UnitOfWork;

namespace SchoolMgt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LabController : ControllerGeneric<Lab>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LabController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetLabDTO>>>> GetAll()
    {
        return await base.GetAll<GetLabDTO>();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse<GetLabDTO>>> GetSingle(int id)
    {
        return await base.GetSingle<GetLabDTO>(id);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<bool>>> Add(AddLabDTO lab)
    {
        return await base.Add<AddLabDTO>(lab);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Update(int id, UpdateLabDTO lab)
    {
        return await base.Update<UpdateLabDTO>(id, lab);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        return await base.Delete(id);
    }
}
