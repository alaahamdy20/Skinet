using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrasturcure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Skinet.Errors;

namespace Skinet.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(options=>
            options.InvalidModelStateResponseFactory = actionContext => {
                var errors = actionContext.ModelState
                    .Where(e=>e.Value.Errors.Count > 0)
                    .SelectMany(x=>x.Value.Errors)
                    .Select(e=>e.ErrorMessage).ToArray();

                var response = new ApiVailadtionErrorResponse(){
                    Errors = errors
                };
                return new BadRequestObjectResult(response);
            }

            );

            return services;
        }
    }
}