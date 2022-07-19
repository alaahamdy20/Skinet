using AutoMapper;
using Core.Entities;
using Skinet.Dtos;

namespace Skinet.Helpers;

public class ProductUrlResolver : IValueResolver<Product,ProductToReturnDto,string>
{
    private readonly IConfiguration _configuration;

    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
      
        if(!string.IsNullOrEmpty(source.PictureURL))
        {
            return _configuration["ApiUrl"] + source.PictureURL;
        }
        return null;
    }
}