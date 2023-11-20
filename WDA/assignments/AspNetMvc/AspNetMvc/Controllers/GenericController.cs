using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Linq.Expressions;
using System.Text.Json;

namespace AspNetMvc.Controllers;

public class GenericController<T> : Controller where T : class
{
    private readonly IGenericRepository<T> _repository;
    private readonly IMapper _mapper;

    public GenericController(IGenericRepository<T> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    
    protected async Task<IActionResult> Get<TGetDto>(string routeName, RequestParams? requestParams, Expression<Func<T, bool>>? filter, Expression<Func<T, bool>>? searchPredicate, List<string>? includes, Sort<T>[]? sortPredicates)
    {
        var serviceResponse = new ServiceResponse<object>();
        var pagedList = await _repository.Get(requestParams, filter, searchPredicate, includes, sortPredicates);

        var shapedData = new List<ExpandoObject>();

        if (requestParams is not null && requestParams.Fields is not null)
        {
            try
            {
                foreach (var e in pagedList)
                {
                    shapedData.Add(e.Shape(requestParams.Fields));
                }
                serviceResponse.Data = shapedData;
            }
            catch (ArgumentException ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
                return BadRequest(serviceResponse);
            }      
        }
        else serviceResponse.Data = pagedList.Select(e => _mapper.Map<TGetDto>(e));

        var paginationMetadata = new PaginationMetadata
        {       
            Count = pagedList.Count,
            PageSize = pagedList.PageSize,
            PageNumber = pagedList.PageNumber,
            TotalPages = pagedList.TotalPages          
        };
        
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
        return Ok(serviceResponse);
    }

    protected async Task<ActionResult<ServiceResponse<TGetDto>>> Get<TGetDto>(Expression<Func<T, bool>> filter, List<string>? includes)
    {
        throw new NotImplementedException();
    }

    protected async Task<ActionResult<ServiceResponse<object>>> Create<TGetDto, TCreateDto>(TCreateDto createDto, string routeName)
    {
        throw new NotImplementedException();
    }

    protected async Task<ActionResult<ServiceResponse<object>>> Update<TUpdateDto>(object id, TUpdateDto updateDto)
    {
        throw new NotImplementedException();
    }

    protected async Task<ActionResult<ServiceResponse<object>>> Delete(object id)
    {
        throw new NotImplementedException();
    }
}
