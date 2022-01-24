using Microsoft.AspNetCore.Builder;

namespace CarSystem.Middlewares.Extensions
{
    public static class SeedMakesExtension
    {
        public static IApplicationBuilder UseSeedMakesMiddleware(
          this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedMakesMiddleware>();
        }
    }
}
