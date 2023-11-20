﻿using AspNetMvc.DTOs;
using AspNetMvc.Entities;
using AutoMapper;

namespace AspNetMvc.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Product, ProductGetDto>().AfterMap((p, pdto) => pdto.Category.Products = null);
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
