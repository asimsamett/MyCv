using FluentValidation.TestHelper;
using MyCv.Application.CQRS.ClientCQ.ClientQueries;
using NUnit.Framework;
using System;

namespace MyCv.Application.Tests.CQRS.Queries
{
    [TestFixture]
    public class GetClientByIdQueryValidationTests
    {
        private GetClientByIdQueryValidation _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GetClientByIdQueryValidation();
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            // Arrange (Hazırlık)
            var query = new GetClientByIdQuery(Guid.Empty);

            // Act (Aksiyon)
            var result = _validator.TestValidate(query);

            // Assert (Doğrulama)
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorMessage("Id alanı boş geçilemez.");
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Invalid_Guid()
        {
            // Arrange
            var invalidGuid = new Guid("00000000-0000-0000-0000-000000000000"); // Geçersiz bir GUID değeri
            var query = new GetClientByIdQuery(invalidGuid);

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorMessage("Geçerli bir GUID değil.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Id_Is_Valid()
        {
            // Arrange
            var validGuid = Guid.NewGuid(); // Geçerli bir GUID
            var query = new GetClientByIdQuery(validGuid);

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }
    }
}
