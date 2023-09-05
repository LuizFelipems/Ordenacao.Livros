namespace Ordenacao.Application.Handlers.Books.Responses
{
    public record BookResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int EditionYear { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
