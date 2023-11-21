using AspNetMvc.Enums;
using AspNetMvc.Extensions;
using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
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
        var pagedList = await _repository.Get(requestParams, filter, searchPredicate, includes, sortPredicates);
        var paginationMetadata = new PaginationMetadata
        {
            Count = pagedList.Count,
            PageSize = pagedList.PageSize,
            PageNumber = pagedList.PageNumber,
            TotalPages = pagedList.TotalPages
        };
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        var isHateoasRequested = IsHateoasRequested(Request);     

        if (!isHateoasRequested && requestParams?.Fields is null)
        {             
            var data = pagedList.Select(e => _mapper.Map<TGetDto>(e));
            return Ok(data);
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
                return Ok(shapedData);
            }
            catch (ArgumentException ex)
            {               
                return BadRequest(ex.Message);
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
                return Ok(new { Data = shapedData, Links = CreateHateoasLinksForCollection(routeName, pagedList.HasNextPage, pagedList.HasPreviousPage, requestParams) });
            }
            catch (ArgumentException ex)
            {              
                return BadRequest(ex.Message);
            }
            
        }            
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
                Href = Url.Link($"FullyUpdate{typeName}", new { id }),
                Rel = "fully-update",
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

    protected async Task<IActionResult> Get<TGetDto>(Expression<Func<T, bool>> predicate, List<string>? includes)
    {
        var entity = await _repository.Get(predicate, includes);
        if (entity is null) 
            return NotFound("Cannot find a result with that Id");      
        if (IsHateoasRequested(Request)) 
            return Ok(new { Data = _mapper.Map<TGetDto>(entity), Links = CreateHateoasLinksForItem(entity) });
        else 
            return Ok(_mapper.Map<TGetDto>(entity));
    }

    protected async Task<IActionResult> Create<TGetDto, TCreateDto>(TCreateDto createDto, string routeName)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        var entity = _mapper.Map<T>(createDto);
        _repository.Create(entity);
        await _repository.SaveAsync();
        var getDto = _mapper.Map<TGetDto>(entity);
        var shapedGetDto = getDto.Shape(null) as IDictionary<string, object?>;
        shapedGetDto.Add("links", CreateHateoasLinksForItem(entity));
        return CreatedAtRoute(routeName, new { id = shapedGetDto["Id"] }, shapedGetDto);
    }

    private bool IsHateoasRequested(HttpRequest request)
    {
        return request.Headers.Accept.Contains("application/vnd.nghia.hateoas+json");
    }

    protected async Task<IActionResult> FullyUpdate<TUpdateDto>(object id, TUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);
        var entity = await _repository.FindById(id);
        if (entity is null)
            return NotFound();     
        _mapper.Map(updateDto, entity);
        _repository.Update(entity);
        await _repository.SaveAsync();
        return NoContent();
    }

    protected async Task<IActionResult> Delete(object id)
    {
        var entity = await _repository.FindById(id);
        if (entity is null)
            return NotFound();
        _repository.Delete(entity);
        await _repository.SaveAsync();
        return NoContent();
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

    public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
    {
        var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();

        return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
    }
}
