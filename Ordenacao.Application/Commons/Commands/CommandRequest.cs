using MediatR;

namespace Ordenacao.Application.Commons.Commands
{
    public abstract record CommandRequest<TResponse> : IRequest<TResponse>
    {
    }
}
