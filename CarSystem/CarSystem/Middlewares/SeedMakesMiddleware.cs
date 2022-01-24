namespace CarSystem.Middlewares
{
    using CarSystem.Services.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public class SeedMakesMiddleware
    {
        private readonly RequestDelegate next;

        public SeedMakesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var makesService = provider.GetService<IMakesService>();
            if (!makesService.Any())
            {
                var categories = new List<string>
            {
                "BMW",
                "Renault",
                "Mercedes",
                "Audi",
            };

                foreach (var category in categories)
                {
                    await makesService.CreateAsync(category);
                }
            }

            await this.next(context);
        }
    }
}
