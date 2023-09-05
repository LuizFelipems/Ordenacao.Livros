using Bogus;
using Ordenacao.Application.Handlers.Books.Commands;

namespace Shared.Factory
{
    public static class RequestFactory
    {
        public static OrdinationBooksCommand GetOrdinationBooksCommand
            => new Faker<OrdinationBooksCommand>()
                .CustomInstantiator(x => new OrdinationBooksCommand() 
                    { Books = new List<BooksCommand>() 
                        { 
                            GetBookCommand("Java How to Program", "Deitel & Deitel", 2007),
                            GetBookCommand("Patterns of Enterprise Application Architecture", "Martin Fowler", 2002),
                            GetBookCommand("Head First Design Patterns", "Elisabeth Freeman", 2004),
                            GetBookCommand("Internet & World Wide Web: How to Program", "Deitel & Deitel", 2007),
                        } 
                    });

        public static BooksCommand GetBookCommand(string title, string authorName, int editionYear)
            => new Faker<BooksCommand>()
                .RuleFor(x => x.Title, f => title)
                .RuleFor(x => x.AuthorName, f => authorName)
                .RuleFor(x => x.EditionYear, f => editionYear);
    }
}
