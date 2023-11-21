using AspNetMvc.DTOs;
using AspNetMvc.Entities;
using AspNetMvc.Models;
using AspNetMvc.Repositories.GenericRepository;
using AspNetMvc.Services.ShopService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace AspNetMvc.Controllers
{
    [Route("")]
    public class ProductController : GenericController<Product>
    {
        private readonly IShopService _shopRepository;

        public ProductController(IGenericRepository<Product> productRepository, IShopService shopRepository, IMapper mapper) : base(productRepository, mapper)
        {
            _shopRepository = shopRepository;
        }

        [HttpGet("product")]
        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet("api/product", Name = "GetProducts")]
        [Produces("application/json", "application/vnd.nghia.hateoas+json")]
        public async Task<IActionResult> Get([FromQuery] ProductRequestParams? productRequestParams)
        {
            var productSortPredicatesServiceResponse = _shopRepository.ProductSortPredicates(productRequestParams);

            if (!productSortPredicatesServiceResponse.Succeeded)
            {
                return BadRequest(productSortPredicatesServiceResponse);
            }          

            return await base.Get<ProductGetDto>("GetProducts", productRequestParams, _shopRepository.ProductFilterPredicate(productRequestParams), _shopRepository.ProductSearchPredicate(productRequestParams), new List<string> { "Category" }, productSortPredicatesServiceResponse.Data);
        }     

        [HttpGet("api/product/{id}", Name = "GetProduct")]
        [Produces("application/json", "application/vnd.nghia.hateoas+json")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            Expression<Func<Product, bool>> filter = p => p.Id == id;
            return await base.Get<ProductGetDto>(filter, new List<string> { "Category" });
        }

        [HttpPost("api/product")]
        [Consumes("application/json")]
        [Produces("application/json", "application/vnd.nghia.hateoas+json")]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto productCreateDto)
        {
            return await base.Create<ProductGetDto, ProductCreateDto>(productCreateDto, "GetProduct");
        }

        [HttpPut("api/product/{id}", Name = "FullUpdateProduct")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductUpdateDto productUpdateDto)
        {
            return await base.FullyUpdate<ProductUpdateDto>(id, productUpdateDto);
        }

        [HttpDelete("api/product/{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.Delete(id);
        }
    }
}
