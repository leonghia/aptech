using AspNetMvc.DTOs;
using AspNetMvc.Entities;
using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Services.ShopService;
using AspNetMvc.Utilities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace AspNetMvc.Controllers
{
    [Route("[controller]")]
    public class ProductController : GenericController<Product>
    {
        private readonly IShopService _shopRepository;

        public ProductController(IGenericRepository<Product> productRepository, IShopService shopRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get", Name = "GetProducts")]
        public async Task<IActionResult> Get([FromQuery] ProductRequestParams? productRequestParams)
        {
            var productSortPredicatesServiceResponse = _shopRepository.ProductSortPredicates(productRequestParams);

            if (!productSortPredicatesServiceResponse.Succeeded)
            {
                return BadRequest(productSortPredicatesServiceResponse);
            }          

            return await base.Get<ProductGetDto>("GetProducts", productRequestParams, _shopRepository.ProductFilterPredicate(productRequestParams), _shopRepository.ProductSearchPredicate(productRequestParams), new List<string> { "Category" }, productSortPredicatesServiceResponse.Data);
        }     

        [HttpGet("get/{id}", Name = "GetProduct")]
        public async Task<ActionResult<ServiceResponse<ProductGetDto>>> Get([FromRoute] int id)
        {
            Expression<Func<Product, bool>> filter = p => p.Id == id;
            return await base.Get<ProductGetDto>(filter, new List<string> { "Category" });
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<object>>> Create([FromBody] ProductCreateDto productCreateDto)
        {
            return await base.Create<ProductGetDto, ProductCreateDto>(productCreateDto, "GetProduct");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> Update([FromRoute] int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            return await base.Update<ProductUpdateDto>(id, productUpdateDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<object>>> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }
    }
}
