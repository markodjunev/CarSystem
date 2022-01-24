using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CarSystem.Services.Interfaces;

namespace CarSystem.Middlewares
{
    public class SeedModelsMiddleware
    {
        private readonly RequestDelegate next;

        public SeedModelsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var modelsService = provider.GetService<IModelsService>();
            if (!modelsService.Any())
            {
                var models = new List<(string Name, int MakeId)>
            {
                ("X5", 1),
                ("M3", 1),
                ("X3", 1),
                ("Clio", 2),
                ("Megane", 2),
                ("Megane Sport", 2),
                ("S500", 3),
                ("S350", 3),
                ("C220", 3),
                ("A8", 4),
                ("A6", 4),

            };

                foreach (var model in models)
                {
                    await modelsService.CreateAsync(model.Name, model.MakeId);
                }
            }

            await this.next(context);
        }
    }
}
