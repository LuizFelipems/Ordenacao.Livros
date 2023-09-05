using AutoMapper;
using FluentValidation.Results;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Resources;
using Ordenacao.Domain.Interfaces.Data;
using Ordenacao.Domain.Models.Base;

namespace Ordenacao.Application.Commons.Handlers
{
    public abstract class Handler
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public Handler(IUnitOfWork uow,
                        IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        protected ValidationResult ValidationResult { get; } = new ValidationResult();

        protected async Task<bool> IsValidAsync<TParameter>(TParameter target) where TParameter : Entity<TParameter>
        {
            await target.IsValidAsync();
            foreach (var error in target.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected async Task<ValidationResult> CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_uow.HasChanges() && (await _uow.SaveAsync(cancellationToken) <= 0))
                AddError(ValidationMessages.CommitErrorMessage);

            return ValidationResult;
        }

        protected bool IsValid()
        {
            return ValidationResult.IsValid;
        }

        protected bool IsSuccess(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected Response<TData> Success<TData>(TData data)
        {
            return Response<TData>.Success(data, ValidationResult);
        }

        protected Response<TData> Fail<TData>()
        {
            return Response<TData>.Fail(ValidationResult);
        }
    }
}
