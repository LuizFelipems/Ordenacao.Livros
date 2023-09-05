using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ordenacao.Infra.Data.DataContexts.Configurations
{
    public static class ContextConfiguration
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>()?
                .CreateScope();

            using var context = serviceScope?.ServiceProvider.GetService<AppDbContext>();
            context?.Database.Migrate();
        }
    }
}
