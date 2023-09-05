using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ordenacao.Infra.Data.DataContexts
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public const string ConnectionStringName = "DbContext";

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString(ConnectionStringName);
                options.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Model.GetEntityTypes().ToList().ForEach(entityType =>
            {
                entityType.SetTableName(entityType.DisplayName());

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);

                entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(string))
                    .Select(p => modelBuilder.Entity(p.DeclaringEntityType.ClrType).Property(p.Name))
                    .ToList()
                    .ForEach(property =>
                    {
                        property.IsUnicode(false);
                        property.HasMaxLength(2000);
                    });
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
