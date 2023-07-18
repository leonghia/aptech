using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMgt.Models;
using SchoolMgt.Repository;
using SchoolMgt.UnitOfWork;

namespace SchoolMgt;

public class ControllerGeneric<TEntity> : ControllerBase where TEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly string _entityName = typeof(TEntity).Name;

    public ControllerGeneric(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ActionResult<ServiceResponse<List<TDAO>>>> GetAll<TDAO>()
    {
        var response = new ServiceResponse<List<TDAO>>();
        
        try
        {
            var repo = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
            var results = await repo.GetAll();
            var resultsDTO = results.Select(r => _mapper.Map<TDAO>(r)).ToList();
            response.Data = resultsDTO;
            response.Message = $"Get {_entityName}s successfully";
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Get {_entityName}s failed: " + ex.Message;
            return StatusCode(500, response);
        }
    }

    public async Task<ActionResult<ServiceResponse<TDAO>>> GetSingle<TDAO>(int id)
    {
        var response = new ServiceResponse<TDAO>();
        try
        {
            var repo = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
            var result = await repo.GetSingle(id);
            if (result is not null)
            {
                response.Data = _mapper.Map<TDAO>(result);
                response.Message = $"Get {typeof(TEntity)} successfully";
                return Ok(response);
            }
            response.Message = $"Get {_entityName} failed: {_entityName} not found";
            response.Success = false;
            return StatusCode(404, response);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Get {_entityName} failed: " + ex.Message;
            return StatusCode(500, response);
        }
    }

    public async Task<ActionResult<ServiceResponse<bool>>> Add<TDAO>(TDAO entity)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var repo = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
            repo.Add(_mapper.Map<TEntity>(entity));
            await _unitOfWork.Save();
            response.Message = $"Add {_entityName} successfully";
            response.Data = true;
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Add {_entityName} failed: " + ex.Message;
            return StatusCode(500, response);
        }
    }

    public async Task<ActionResult<ServiceResponse<bool>>> Update<TDAO>(int id, TDAO entity)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var repo = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
            var result = await repo.GetSingle(id);
            _mapper.Map(entity, result);
            repo.Update(result);
            await _unitOfWork.Save();
            response.Data = true;
            response.Message = $"Update {_entityName} successfully";
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Update {_entityName} failed: " + ex.Message;
            return StatusCode(500, response);
        }
    }

    public async Task<ActionResult<ServiceResponse<bool>>> Delete(int id)
    {
        var response = new ServiceResponse<bool>();
        try
        {
            var repo = (GenericRepository<TEntity>)_unitOfWork.GetType().GetProperty($"{_entityName}Repository").GetValue(_unitOfWork, null);
            repo.Delete(id);
            await _unitOfWork.Save();
            response.Data = true;
            response.Message = $"Delete {_entityName} successfully";
            return Ok(response);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"Delete {_entityName} failed: " + ex.Message;
            return StatusCode(500, response);
        }
    }
}
