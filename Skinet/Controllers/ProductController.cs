using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrasturcure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skinet.Dtos;

namespace Skinet.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _brandsRepository;
        private readonly IGenericRepository<ProductType> _typesRepository;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> brandsRepository, IGenericRepository<ProductType> typesRepository, IMapper
                mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _brandsRepository = brandsRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts(string sort) => Ok(
            _mapper.Map<IEnumerable<ProductToReturnDto>>(
                await _productRepository.GetAllBySpecificationAsync(new ProductsWithTypesAndBrands(sort))));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id) => Ok(
            _mapper.Map<ProductToReturnDto>(
                await _productRepository.GetBySpecificationAsync(new ProductsWithTypesAndBrands(id))));

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands() => Ok(await _brandsRepository.ListAllAsync());

        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProduct() => Ok(await _typesRepository.ListAllAsync());
    }
}