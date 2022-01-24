using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSystem.Middlewares.Extensions
{
    public static class SeedModelExtension
    {
        public static IApplicationBuilder UseSeedModelsMiddleware(
         this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedModelsMiddleware>();
        }
    }
}
