using AspNetMvc.Extensions;
using AspNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc.Controllers
{
    [Route("")]
    public class RootController : Controller
    {

        [HttpGet("api", Name = "GetRoot")]
        [Produces("application/vnd.nghia.hateoas+json")]
        public IActionResult Get()
        {           
            var serviceResponse = new ServiceResponse<object>();

            // create HATEOAS links for root
            var links = new List<HateoasLink>
            {
                new HateoasLink
                {
                    Href = Url.Link("GetRoot", null),
                    Rel = "self",
                    Method = "GET"
                },
                new HateoasLink
                {
                    Href = Url.Link("GetCategories", null),
                    Rel = "get-categories",
                    Method = "GET"
                },
                new HateoasLink
                {
                    Href = Url.Link("GetProducts", null),
                    Rel = "get-products",
                    Method = "GET"
                }
            };

            var shapedServiceResponse = serviceResponse.Shape();

            shapedServiceResponse.TryAdd<string, object?>("links", links);

            return Ok(shapedServiceResponse);
        }
    }
}
