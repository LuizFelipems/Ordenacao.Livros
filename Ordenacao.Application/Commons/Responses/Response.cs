
using FluentValidation.Results;

namespace Ordenacao.Application.Commons.Responses
{
    public class Response<TData>
    {
        public TData? Data { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public bool IsValid => ValidationResult.IsValid;

        public static Response<TData> Success(TData data, ValidationResult? validationResult = default)
        {
            return new Response<TData>
            {
                Data = data,
                ValidationResult = validationResult ?? new ValidationResult()
            };
        }

        public static Response<TData> Fail(ValidationResult? validationResult = default)
        {
            return new Response<TData> { ValidationResult = validationResult ?? new ValidationResult() };
        }
    }
}
