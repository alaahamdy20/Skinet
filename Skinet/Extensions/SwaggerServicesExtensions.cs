using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Extensions
{
    public static class SwaggerServicesExtensions
    {

        public static IApplicationBuilder UseSwaggerDocumention(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;

        }
        public static IServiceCollection AddSwaggerDocumention(this IServiceCollection services){
            services.AddSwaggerGen();

            return services;
        }

    }
}