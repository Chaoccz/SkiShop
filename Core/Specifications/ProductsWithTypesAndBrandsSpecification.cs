using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification: BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(x => (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
            && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId) 
                    && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc": AddOrderBy(x => x.Price); break;
                    case "priceDesc": AddOrderByDesc(x => x.Price);
                        break;
                    default: AddOrderBy(x => x.Name); break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
