﻿using AspNetMvc.Entities;
using AspNetMvc.Models;
using System.Linq.Expressions;

namespace AspNetMvc.Services.ShopService
{
    public interface IShopService
    {
        Expression<Func<Product, bool>>? ProductSearchPredicate(RequestParams? requestParams);
        Expression<Func<Product, bool>>? ProductFilterPredicate(ProductRequestParams? productRequestParams);
        Expression<Func<Category, bool>>? CategorySearchPredicate(RequestParams? requestParams);
        ServiceResponse<Sort<Product>[]?> ProductSortPredicates(ProductRequestParams? productRequestParams);      
    }
}
