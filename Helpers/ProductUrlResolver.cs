﻿using AutoMapper;
using AutoMapper.Execution;
using Core.Entities;
using Ecommerce.API.Dtos;

namespace Ecommerce.API.Helpers
{
    public class ProductUrlResolver: IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
    }
}
