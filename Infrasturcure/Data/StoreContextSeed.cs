using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrasturcure.Data;

public class StoreContextSeed
{
    public static async Task SeedData(StoreContext context, ILoggerFactory loggerFactory)
    {
        try
        {
           
            if (!context.Brands.Any())
            {
                var Data = await File.ReadAllTextAsync("../Infrasturcure/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(Data);
                await context.Brands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }
            if (!context.ProductTypes.Any())
            {
                var Data = await File.ReadAllTextAsync("../Infrasturcure/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(Data);
                await context.ProductTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();

            }
            if (!context.Products.Any())
            {
                var Data = await File.ReadAllTextAsync("../Infrasturcure/SeedData/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(Data);
                await context.Products.AddRangeAsync(Products);
                await context.SaveChangesAsync();

            }
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<StoreContextSeed>();
            logger.LogError(e, "An Error ocured in Seed Data");
        }
    }
}