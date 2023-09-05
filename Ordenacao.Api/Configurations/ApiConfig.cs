namespace Ordenacao.Api.Swagger
{
    public static class ApiConfig
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x => x.EnableAnnotations());
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
