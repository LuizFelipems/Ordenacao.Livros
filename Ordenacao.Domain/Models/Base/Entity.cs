using FluentValidation;
using FluentValidation.Results;
using Ordenacao.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ordenacao.Domain.Models.Base
{
    public abstract class Entity<T> : AbstractValidator<T>, IAggregateRoot
        where T : Entity<T>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime ModifyAt { get; set; }
        public bool Active { get; set; } = true;

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public virtual Task<bool> IsValidAsync() => Task.FromResult(true);

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo is null)
                return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
