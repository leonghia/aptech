using AspNetMvc.Enums;
using AspNetMvc.Extensions;
using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
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

        var paginationMetadata = new PaginationMetadata
        {
            Count = pagedList.Count,
            PageSize = pagedList.PageSize,
            PageNumber = pagedList.PageNumber,
            TotalPages = pagedList.TotalPages
        };
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        var isHateoasRequested = Request.Headers.Accept.Contains("application/vnd.nghia.hateoas+json");     

        if (!isHateoasRequested && requestParams?.Fields is null)
        {             
            serviceResponse.Data = pagedList.Select(e => _mapper.Map<TGetDto>(e));
        }
        else if (!isHateoasRequested && requestParams?.Fields is not null)
        {
            
            try
            {
                var shapedData = new List<ExpandoObject>();
                foreach (var e in pagedList)
                {
                    shapedData.Add(e.Shape(requestParams?.Fields));
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
        else
        {
            try
            {
                var shapedData = new List<ExpandoObject>();
                foreach (var e in pagedList)
                {
                    var temp = e.Shape(requestParams?.Fields);
                    temp.TryAdd("links", CreateHateoasLinksForItem(e));
                    shapedData.Add(temp);
                }
                serviceResponse.Data = shapedData;
                var shapedServiceResponse = serviceResponse.Shape();
                shapedServiceResponse.TryAdd("links", CreateHateoasLinksForCollection(routeName, pagedList.HasNextPage, pagedList.HasPreviousPage, requestParams));
                return Ok(shapedServiceResponse);
            }
            catch (ArgumentException ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
                return BadRequest(serviceResponse);
            }
            
        }      

        return Ok(serviceResponse);
    }

    private IEnumerable<HateoasLink> CreateHateoasLinksForCollection(string routeName, bool hasNextPage, bool hasPreviousPage, RequestParams? requestParams)
    {
        
        var links = new List<HateoasLink>
        {
            new HateoasLink
            {
                Href = CreateResourceUrl(PageType.CurrentPage, routeName, requestParams),
                Rel = "self",
                Method = "GET"
            }
        };
        if (hasNextPage)
        {
            links.Add(new HateoasLink
            {
                Href = CreateResourceUrl(PageType.NextPage, routeName, requestParams),
                Rel = "next-page",
                Method = "GET"
            });
        }
        if (hasPreviousPage)
        {
            links.Add(new HateoasLink
            {
                Href = CreateResourceUrl(PageType.PreviousPage, routeName, requestParams),
                Rel = "previous-page",
                Method = "GET"
            });
        }

        return links;
    }

    private IEnumerable<HateoasLink> CreateHateoasLinksForItem(T entity)
    {

        var typeName = typeof(T).Name;
        var id = typeof(T).GetProperty("Id")?.GetValue(entity);

        var links = new List<HateoasLink>
        {
            new HateoasLink
            {
                Href = Url.Link($"Get{typeName}", new { id }),
                Rel = "self",
                Method = "GET"
            },
            new HateoasLink
            {
                Href = Url.Link($"FullUpdate{typeName}", new { id }),
                Rel = "full-update",
                Method = "PUT"
            },
            new HateoasLink
            {
                Href = Url.Link($"Delete{typeName}", new { id }),
                Rel = "delete",
                Method = "DELETE"
            }
        };    

        return links;
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

    private string? CreateResourceUrl(PageType pageType, string routeName, RequestParams? requestParams)
    {
        RequestParams rP;
        switch (typeof(T).Name)
        {
            case "Product":
                requestParams ??= new ProductRequestParams();
                var temp = (ProductRequestParams)requestParams;
                rP = new ProductRequestParams
                {
                    Category = temp.Category,
                    Price = temp.Price,
                    Stock = temp.Stock,
                    SalesPerDay = temp.SalesPerDay,
                    SalesPerMonth = temp.SalesPerMonth,
                    Rating = temp.Rating,
                    Sales = temp.Sales,
                    Revenue = temp.Revenue,
                };
                break;
            case "Category":
            default:
                requestParams ??= new RequestParams();
                rP = new RequestParams(); ;
                break;
        }
        rP.SearchQuery = requestParams.SearchQuery;
        rP.OrderBy = requestParams.OrderBy;
        rP.Fields = requestParams.Fields;
        rP.PageSize = requestParams.PageSize;
        rP.PageNumber = requestParams.PageNumber;
        switch (pageType)
        {
            case PageType.PreviousPage:
                rP.PageNumber--;
                return Url.Link(routeName, rP);
            case PageType.NextPage:
                rP.PageNumber++;
                return Url.Link(routeName, rP);
            default:
                return Url.Link(routeName, rP);
        }
    }
}
