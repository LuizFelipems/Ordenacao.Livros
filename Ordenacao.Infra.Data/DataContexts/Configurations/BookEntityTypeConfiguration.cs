using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordenacao.Domain.Models;
using Ordenacao.Infra.Data.DataContexts.Configurations.Base;

namespace Ordenacao.Infra.Data.DataContexts.Configurations
{
    public class BookEntityTypeConfiguration : EntityTypeConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.HasQueryFilter(x => x.Active);

            builder.Property(x => x.Title)
                   .IsRequired();

            builder.Property(x => x.AuthorName)
                   .IsRequired();
            
            builder.Property(x => x.EditionYear)
                   .IsRequired();
        }
    }
}
