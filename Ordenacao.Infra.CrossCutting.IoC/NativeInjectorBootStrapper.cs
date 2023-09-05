using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ordenacao.Application;
using Ordenacao.Application.AutoMapper;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Interfaces.Data.Repositories;
using Ordenacao.Domain.Interfaces.Services;
using Ordenacao.Infra.Data.DataContexts;
using Ordenacao.Infra.Data.Repositories;
using Ordenacao.Infra.Data.Services;
using Ordenacao.Infra.Data.UoW;

namespace Ordenacao.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Pin));
            AutoMapperConfig.RegisterMappings();

            services.AddSingleton(new JsonSerializer
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });
            
            services.AddScoped<IBooksOrdererService, BooksOrdererService>();

            RegisterDataAccess(services);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Pin).Assembly));
        }

        private static void RegisterDataAccess(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}
