using Domain.Exceptions;
using KCVA.TestHelpers.Fakers.Shared;

namespace KCVA.UnitTests.Features.Shared
{
    public sealed class EmailTests
    {
        [Fact]
        public void Is_valid_email()
        {
            var sut = EmailFaker.Create().Generate();

            sut.Value.Should().Match("*@*.com");
        }

        [Fact]
        public void Is_empty_email()
        {
            Invoking(() => EmailFaker.CreateWithParams("").Generate())
                .Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Is_invalid_email()
        {
            Invoking(() => EmailFaker.CreateWithParams("test").Generate())
                .Should().Throw<DomainException>();
        }
    }
}
