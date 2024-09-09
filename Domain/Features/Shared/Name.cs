using Domain.Exceptions;
using Domain.SeedWork;
using EnsureThat;

namespace Domain.Features.Shared
{
    public sealed class Name : ValueObject
    {
        public const int MAX_VALUE = 255;
        public Name(string value)
        {
            Validate(value);
            Value = value;
        }

        public string Value { get; private set; }

        public void Validate(string value)
        {
            EnsureArg.IsNotNullOrEmpty(value);
            if (value.Length > MAX_VALUE)
            {
                throw new DomainException($"{nameof(Name)} cannot be longer than 255 letters");
            }
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return "";
        }
    }
}
