using Domain.Exceptions;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.UnitTests.Features.Shared
{
    public sealed class NameTests
    {
        [Fact]
        public void Name_should_have_a_value()
        {
            var sut = new NameFaker().Generate();

            sut.Value.Should().NotBe("");
            sut.Value.Should().NotBe(null);
        }

        [Fact]
        public void Name_should_should_exist()
        {
            Invoking(() => NameFaker.CreateWithParams(null).Generate())
                .Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Name_should_have_a_maximum_number_of_letters()
        {
            Invoking(() => NameFaker.ExceedCharacterLimit().Generate())
                .Should().Throw<DomainException>();
        }
    }
}
