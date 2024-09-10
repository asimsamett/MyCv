using FluentValidation.TestHelper;
using MyCv.Application.CQRS.ClientCQ.ClientDelete;

namespace UnitTestExample.ClientWriteUnitTest
{
    [TestFixture]
    public class DeleteClientCommandUnitTest
    {
        private DeleteClientCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new DeleteClientCommandValidator();
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            // Arrange
            var command = new DeleteClientCommand(Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                  .WithErrorMessage("Id Alanı Boş Geçilmez");
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Invalid_Guid()
        {
            // Arrange
            var invalidGuid = Guid.Empty; // Invalid GUID olarak kabul edilir
            var command = new DeleteClientCommand(invalidGuid);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                  .WithErrorMessage("Id alanı boş GUID olamaz.");
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Guid_Empty()
        {
            // Arrange
            var command = new DeleteClientCommand(Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                  .WithErrorMessage("Id alanı boş GUID olamaz.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Id_Is_Valid()
        {
            // Arrange
            var validGuid = Guid.NewGuid();
            var command = new DeleteClientCommand(validGuid);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }
    }
}
