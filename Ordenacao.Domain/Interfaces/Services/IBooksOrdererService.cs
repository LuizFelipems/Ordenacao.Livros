using Ordenacao.Domain.Models;

namespace Ordenacao.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface do serviço de ordenação de livros
    /// </summary>
    public interface IBooksOrdererService
    {
        /// <summary>
        /// Ordena os livros do CSO
        /// </summary>
        /// <param name="livros">Coleção de Livros recebida a ser ordenada</param>
        public List<Book> Orderer(List<Book> books);
    }
}
