using MediatR;

namespace Ordenacao.Application.Commons.Queries
{
    public record Query<TResponse> : IRequest<TResponse>
    {
    }
}
