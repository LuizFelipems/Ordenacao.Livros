using Ordenacao.Domain.Models;
using Ordenacao.Infra.CrossCutting.Commons.Exceptions;
using Ordenacao.Infra.Data.Services;
using Shared.Factory;
using System.Configuration;

namespace Ordenacao.Application.Tests.Services
{
    public class BooksOrdererServiceTest
    {
        private List<Book> Books;
        private Book Book1, Book2, Book3, Book4;

        public BooksOrdererServiceTest()
        {
            Books = DomainFactory.GetBooks;

            Book1 = Books[0];
            Book2 = Books[1];
            Book3 = Books[2];
            Book4 = Books[3];
        }

        private BooksOrdererService InitializeService() => new();

        /// <summary>
        /// Método de teste do primeiro UseCase, com o Título ascendente
        /// </summary>
        [Fact]
        public void WhenTitleAsc()
        {
            #region Arrange
            ConfigurationManager.AppSettings["Title"] = "asc";
            ConfigurationManager.AppSettings["AuthorName"] = "asc";
            ConfigurationManager.AppSettings["EditionYear"] = "asc";

            var service = InitializeService();
            #endregion

            #region Act
            var result = service.Orderer(Books);
            #endregion

            #region Assert
            Assert.Equal(result[0].Title, Book3.Title);
            Assert.Equal(result[1].Title, Book4.Title);
            Assert.Equal(result[2].Title, Book1.Title);
            Assert.Equal(result[3].Title, Book2.Title);
            #endregion
        }

        /// <summary>
        /// Método de teste do segundo UseCase, com o Autor ascendente e o Titulo descendente
        /// </summary>
        [Fact]
        public void WhenAuthorName_Asc_And_Title_Desc()
        {
            #region Arrange
            ConfigurationManager.AppSettings["AuthorName"] = "asc";
            ConfigurationManager.AppSettings["Title"] = "desc";
            ConfigurationManager.AppSettings["EditionYear"] = "asc";

            var service = InitializeService();
            #endregion

            #region Act
            var result = service.Orderer(Books);
            #endregion

            #region Assert
            Assert.Equal(result[0].Title, Book1.Title);
            Assert.Equal(result[1].Title, Book4.Title);
            Assert.Equal(result[2].Title, Book3.Title);
            Assert.Equal(result[3].Title, Book2.Title);
            #endregion
        }

        /// <summary>
        /// Método de teste do terceiro UseCase, com a edição descendente, o autor descendente e o Título ascendente
        /// </summary>
        [Fact]
        public void WhenEdition_Desc_AND_Author_Desc_AND_Title_Asc()
        {
            #region Arrange
            ConfigurationManager.AppSettings["EditionYear"] = "desc";
            ConfigurationManager.AppSettings["AuthorName"] = "desc";
            ConfigurationManager.AppSettings["Title"] = "asc";

            var service = InitializeService();
            #endregion

            #region Act
            var result = service.Orderer(Books);
            #endregion

            #region Assert
            Assert.Equal(result[0].Title, Book4.Title);
            Assert.Equal(result[1].Title, Book1.Title);
            Assert.Equal(result[2].Title, Book3.Title);
            Assert.Equal(result[3].Title, Book2.Title);
            #endregion
        }

        /// <summary>
        /// Método de teste do quarto UseCase, quando os parâmetros são nulos
        /// </summary>
        [Fact]
        public void WhenParameters_Is_Null()
        {
            #region Arrange
            ConfigurationManager.AppSettings["EditionYear"] = null;
            ConfigurationManager.AppSettings["AuthorName"] = null;
            ConfigurationManager.AppSettings["Title"] = null;

            var service = InitializeService();
            #endregion

            #region Act
            var exception = Record.Exception(() => service.Orderer(Books));
            #endregion

            #region Assert
            Assert.NotNull(exception);
            Assert.IsType<OrdererException>(exception);
            #endregion
        }

        /// <summary>
        /// Método de teste do último UseCase, quando quando os parâmetros são vazios
        /// </summary>
        [Fact]
        public void WhenParameters_Is_Empty()
        {
            #region Arrange
            ConfigurationManager.AppSettings["EditionYear"] = "";
            ConfigurationManager.AppSettings["AuthorName"] = "";
            ConfigurationManager.AppSettings["Title"] = "";

            var service = InitializeService();
            #endregion

            #region Act
            var result = service.Orderer(Books);
            #endregion

            #region Assert
            Assert.Empty(result);
            #endregion
        }
    }
}
