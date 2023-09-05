using Ordenacao.Domain.Interfaces.Services;
using Ordenacao.Domain.Models;
using Ordenacao.Infra.CrossCutting.Commons.Exceptions;
using System.Configuration;

namespace Ordenacao.Infra.Data.Services
{
    /// <summary>
    /// Implementação da interface de Ordenação dos livros solicitada pelo CSO
    /// </summary>
    public class BooksOrdererService : IBooksOrdererService
    {
        /// <summary>
        /// Propriedades que inicializão com as configurações do arquivo App.Config
        /// </summary>
        private string Title { get; set; }
        private string AuthorName { get; set; }
        private string EditionYear { get; set; }

        public BooksOrdererService()
        {
            Title = ConfigurationManager.AppSettings["Title"];
            AuthorName = ConfigurationManager.AppSettings["AuthorName"];
            EditionYear = ConfigurationManager.AppSettings["EditionYear"];
        }

        /// <summary>
        /// Implementação do método que ordena os livros
        /// </summary>
        /// <param name="books">Coleção de livros recebida a ser ordenada</param>
        /// </param>
        public List<Book> Orderer(List<Book> books)
        {
            List<Book> result = null;

            AppConfigIsNull();

            if (books is null || AppConfigIsEmpty())
                return new List<Book>();

            if (Title is "asc" && AuthorName is "desc" && EditionYear == "desc")
                result = books.OrderByDescending(e => e.EditionYear).ThenByDescending(a => a.AuthorName).ThenBy(t => t.Title).ToList();
            else if (AuthorName is "asc" && Title is "desc")
                result = books.OrderBy(e => e.AuthorName).ThenByDescending(a => a.Title).ToList();
            else if (Title is "asc")
                result = books.OrderBy(e => e.Title).ToList();

            return result.ToList();
        }

        public void AppConfigIsNull()
        {
            if (Title is null || AuthorName is null || EditionYear is null)
                throw new OrdererException(ExceptionMessages.OptionInvalid);
        }

        public bool AppConfigIsEmpty()
        {
            if (Title.Equals("") || AuthorName.Equals("") || EditionYear.Equals(""))
                return true; 
            
            return false;
        }
    }
}
