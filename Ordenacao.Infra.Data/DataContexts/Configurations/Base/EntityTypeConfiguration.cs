using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Ordenacao.Domain.Models.Base;

namespace Ordenacao.Infra.Data.DataContexts.Configurations.Base
{
    public class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity : Entity<TEntity>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.CreateAt)
                   .HasDefaultValueSql("now()")
                   .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

        }
    }
}
