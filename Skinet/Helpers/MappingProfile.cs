using AutoMapper;
using Core.Entities;
using Skinet.Dtos;

namespace Skinet.Helpers;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.PictureURL, o => o.MapFrom<ProductUrlResolver>());
    }
}