using Domain.Exceptions;
using Domain.SeedWork;
using EnsureThat;
using System.Text.RegularExpressions;

namespace Domain.Features.Shared
{
    public sealed class Email : ValueObject
    {
        public const string IsValid = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        public Email() { }

        public Email(string value)
        {
            Validate(value);
            Value = value;
        }


        public string Value { get; private set; }

        public void Validate(string value)
        {
            if (!Regex.IsMatch(value, IsValid))
            {
                throw new DomainException($"{Value}, is not a valid email address, please provide a valid email address");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return "";
        }
    }
}
