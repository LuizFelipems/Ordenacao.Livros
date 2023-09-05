using FluentValidation;
using Ordenacao.Application.Resources;
using Ordenacao.Domain.Models;

namespace Ordenacao.Application.Handlers.Books.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(a => a.Title)
                    .NotNull().WithMessage(ValidationMessages.RequiredProperty)
                    .NotEmpty().WithMessage(ValidationMessages.RequiredProperty)
                    .MaximumLength(1).WithMessage(ValidationMessages.InvalidPropertyLength);

            RuleFor(a => a.AuthorName)
                    .NotNull().WithMessage(ValidationMessages.RequiredProperty)
                    .NotEmpty().WithMessage(ValidationMessages.RequiredProperty)
                    .MaximumLength(1).WithMessage(ValidationMessages.InvalidPropertyLength);

            RuleFor(a => a.EditionYear)
                    .LessThanOrEqualTo(1).WithMessage(ValidationMessages.InvalidPropertyLength);
        }
    }
}
