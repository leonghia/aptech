using AspNetMvc.DTOs;
using AspNetMvc.Entities;
using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Services.ShopService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace AspNetMvc.Controllers
{
    [Route("")]
    public class CategoryController : GenericController<Category>
    {
        private readonly IShopService _shopRepository;

        public CategoryController(IGenericRepository<Category> categoryRepository, IShopService shopRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet("category")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("api/category", Name = "GetCategories")]
        public async Task<IActionResult> Get([FromQuery] RequestParams? requestParams)
        {
            return await base.Get<CategoryGetDto>("GetCategories", requestParams, null, _shopRepository.CategorySearchPredicate(requestParams), new List<string> { "Products" }, null);
        }

        [HttpGet("api/category/{id}", Name = "GetCategory")]
        public async Task<ActionResult<ServiceResponse<CategoryGetDto>>> Get([FromRoute] int id)
        {
            Expression<Func<Category, bool>> filter = c => c.Id == id;
            return await base.Get<CategoryGetDto>(filter, new List<string> { "Products" });
        }

        [HttpPost("api/category")]
        public async Task<ActionResult<ServiceResponse<object>>> Create([FromBody] CategoryCreateDto categoryCreateDto)
        {
            return await base.Create<CategoryGetDto, CategoryCreateDto>(categoryCreateDto, "GetCategory");
        }

        [HttpPut("api/category/{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> Update([FromRoute] int id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            return await base.Update<CategoryUpdateDto>(id, categoryUpdateDto);
        }

        [HttpDelete("api/category/{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }
    }
}
