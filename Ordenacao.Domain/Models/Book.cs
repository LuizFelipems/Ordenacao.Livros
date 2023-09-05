using Ordenacao.Domain.Models.Base;

namespace Ordenacao.Domain.Models
{
    public class Book : Entity<Book>
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int EditionYear { get; set; }
    }
}
