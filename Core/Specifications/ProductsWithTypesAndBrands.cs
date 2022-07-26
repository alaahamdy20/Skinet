using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithTypesAndBrands :BaseSpecifications<Product>
{
    public ProductsWithTypesAndBrands(ProductSpecParams productParams)
    : base(p=> 
        (string.IsNullOrEmpty(productParams.Search) || p.Name.ToLower().Contains(productParams.Search) ) &&
        (!productParams.BrandId.HasValue || p.ProductBrandId == productParams.BrandId) &&
        (!productParams.TypeId.HasValue || p.ProductTypeId == productParams.TypeId)
    )
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
        AddOrderBy(p => p.Name);
        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p=>p.Name);
                    break;
            }
        }
    }

    public ProductsWithTypesAndBrands(int id) : base(x => x.Id == id)
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
    }
   
}