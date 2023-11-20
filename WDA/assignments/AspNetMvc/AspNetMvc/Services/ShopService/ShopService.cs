using AspNetMvc.Entities;
using AspNetMvc.Enums;
using AspNetMvc.Models;
using LinqKit;
using System.Linq.Expressions;
using System.Security.Policy;

namespace AspNetMvc.Services.ShopService
{
    public class ShopService : IShopService
    {

        private readonly Dictionary<string, Expression<Func<Product, object>>> _productPropertySortMappings = new()
        {
            { "id", p => p.Id },
            { "name", p => p.Name },
            { "price", p => p.Price },
            { "stock", p => p.Stock },
            { "salesPerDay", p => p.SalesPerDay },
            { "salesPerMonth", p => p.SalesPerMonth },
            { "rating", p => p.Rating },
            { "sales", p => p.Sales },
            { "revenue", p => p.Revenue },
            { "lastUpdate", p => p.LastUpdate }
        };

        public Expression<Func<Category, bool>>? CategorySearchPredicate(RequestParams? requestParams)
        {
            if (!string.IsNullOrWhiteSpace(requestParams?.SearchQuery))
            {
                var searchQuery = requestParams.SearchQuery.Trim().ToUpper();
                Expression<Func<Category, bool>> predicate = c => c.Name.ToUpper().Contains(searchQuery);
                return predicate;
            }
            return null;
        }

        public Expression<Func<Product, bool>>? ProductFilterPredicate(ProductRequestParams? productRequestParams)
        {
            if (productRequestParams is null) return null;
            var predicate = PredicateBuilder.New<Product>(true);
            if (productRequestParams.Category is not null)
            {
                predicate = predicate.And(p => p.CategoryId == productRequestParams.Category);
            }
            if (productRequestParams.Price is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.Price);
                predicate = predicate.And(p => p.Price >= tuple.Item2 && p.Price <= tuple.Item3);

            }
            if (productRequestParams.Stock is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.Stock);
                predicate = predicate.And(p => p.Stock >= tuple.Item2 && p.Stock <= tuple.Item3);
            }
            if (productRequestParams.SalesPerDay is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.SalesPerDay);
                predicate = predicate.And(p => p.SalesPerDay >= tuple.Item2 && p.SalesPerDay <= tuple.Item3);
            }
            if (productRequestParams.SalesPerMonth is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.SalesPerMonth);
                predicate = predicate.And(p => p.SalesPerMonth >= tuple.Item2 && p.SalesPerMonth <= tuple.Item3);
            }
            if (productRequestParams.Rating is not null && productRequestParams.Rating > 0) predicate = predicate.And(p => p.Rating >= productRequestParams.Rating && p.Rating < productRequestParams.Rating + 1);
            if (productRequestParams.Sales is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.Sales);
                predicate = predicate.And(p => p.Sales >= tuple.Item2 && p.Sales <= tuple.Item3);
            }
            if (productRequestParams.Revenue is not null)
            {
                var tuple = ValidateNumberRange(productRequestParams.Revenue);
                predicate = predicate.And(p => p.Revenue >= tuple.Item2 && p.Revenue <= tuple.Item3);
            }


            return predicate;
        }

        private Tuple<bool, int, int> ValidateNumberRange(string numberFromTo)
        {
            var arr = numberFromTo.Split("-");
            if (int.TryParse(arr[0], out int numberFrom) && int.TryParse(arr[1], out int numberTo) && numberFrom < numberTo)
            {
                return new Tuple<bool, int, int>(true, numberFrom, numberTo);
            }
            return new Tuple<bool, int, int>(false, 0, 0);
        }

        public Expression<Func<Product, bool>>? ProductSearchPredicate(RequestParams? requestParams)
        {
            if (!string.IsNullOrWhiteSpace(requestParams?.SearchQuery))
            {
                var searchQuery = requestParams.SearchQuery.Trim().ToUpper();
                Expression<Func<Product, bool>> predicate = p => p.Name.ToUpper().Contains(searchQuery);
                return predicate;
            }
            return null;
        }

        public ServiceResponse<Sort<Product>[]?> ProductSortPredicates(ProductRequestParams? productRequestParams)
        {
            var serviceResponse = new ServiceResponse<Sort<Product>[]?>();
            if (productRequestParams is null || productRequestParams.OrderBy is null) return serviceResponse;
            // price_asc,salesPerMonth_desc
            var orderByArr = productRequestParams.OrderBy.Split(',');
            var sorts = new List<Sort<Product>>();
            foreach (var o in orderByArr)
            {
                try
                {
                    var orderBy = ParseOrderByFromString(o.Split('_')[0]);
                    var orderType = ParseOrderTypeFromString(o.Split('_')[1]);
                    var sort = new Sort<Product>
                    { OrderBy = orderBy, OrderType = orderType };
                    sorts.Add(sort);
                }
                catch (ArgumentException ex)
                {
                    serviceResponse.Succeeded = false;
                    serviceResponse.Message = ex.Message;
                    return serviceResponse;
                }
            }
            serviceResponse.Data = sorts.ToArray();
            return serviceResponse;
        }

        private OrderType ParseOrderTypeFromString(string orderTypeString)
        {
            if (orderTypeString.ToUpperInvariant().Equals("ASC")) return OrderType.Asc;
            else if (orderTypeString.ToUpperInvariant().Equals("DESC")) return OrderType.Desc;
            else throw new ArgumentException($"Cannot parse '{orderTypeString}' as a valid {nameof(orderTypeString)} argument.");
        }

        private Expression<Func<Product, object>> ParseOrderByFromString(string orderByString)
        {
            if (_productPropertySortMappings.TryGetValue(orderByString, out var predicate)) return predicate;
            else throw new ArgumentException($"Cannot parse '{orderByString}' as a valid {nameof(orderByString)} argument.");
        }

        
    }
}
