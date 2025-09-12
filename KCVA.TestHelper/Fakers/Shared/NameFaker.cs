using AutoBogus;
using Domain.Features.Shared;

namespace KCVA.TestHelpers.Fakers.Shared
{
    public class NameFaker : AutoFaker<Name>
    {
        public NameFaker() {
            this.Locale = "en_GB";
            //RuleFor(x => x.Value, y => y.Random.String(0, Name.MAX_VALUE));
            RuleFor(x => x.Value, y => y.Name.Random.String(0, Name.MAX_VALUE));
        }

        public static NameFaker Create()
        {
            return (NameFaker)new NameFaker()
                .CustomInstantiator(x => new Name(x.Name.FullName()));
        }

        public static NameFaker CreateWithParams(string? value)
        {
            return (NameFaker)new NameFaker()
                .CustomInstantiator(x => new Name(value));
        }

        public static NameFaker ExceedCharacterLimit()
        {
            return (NameFaker)new NameFaker()
                .CustomInstantiator(x => new Name(x.Random.String(Name.MAX_VALUE + 1)));
        }
    }
}
