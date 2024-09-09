using AutoBogus;
using Domain.Features.Shared;

namespace KCVA.TestHelpers.Fakers.Shared
{
    public sealed class EmailFaker : AutoFaker<Email>
    {
        public EmailFaker()
        {
            RuleFor(x => x.Value, y => y.Internet.Email());
        }

        public static EmailFaker Create()
        {
            return (EmailFaker)new EmailFaker()
                .CustomInstantiator(x => new Email(x.Internet.Email()));
        }

        public static EmailFaker CreateWithParams(string value)
        {
            return (EmailFaker)new EmailFaker()
                .CustomInstantiator(x => new Email(value));
        }
    }
}
