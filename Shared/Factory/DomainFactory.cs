using Bogus;
using Ordenacao.Domain.Models;

namespace Shared.Factory
{
    public static class DomainFactory
    {
        public static List<Book> GetBooks
            => new Faker<List<Book>>()
                .CustomInstantiator(x => new List<Book>()
                    {
                        GetBook("Java How to Program", "Deitel & Deitel", 2007),
                        GetBook("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
                        GetBook("Head First Design Patterns", "Elisabeth Freeman", 2004),
                        GetBook("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007),
                    });

        public static Book GetBook(string title, string authorName, int editionYear)
            => new Faker<Book>()
                .RuleFor(x => x.Title, f => title)
                .RuleFor(x => x.AuthorName, f => authorName)
                .RuleFor(x => x.EditionYear, f => editionYear);
    }
}
