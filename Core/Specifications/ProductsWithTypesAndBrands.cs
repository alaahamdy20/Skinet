using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class ProductsWithTypesAndBrands :BaseSpecifications<Product>
{
    public ProductsWithTypesAndBrands()
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
    }

    public ProductsWithTypesAndBrands(int id) : base(x => x.Id == id)
    {
        AddInclude(p => p.ProductType);
        AddInclude(p => p.ProductBrand);
    }
   
}