using FluentValidation.TestHelper;
using MyCv.Application.CQRS.ClientCQ.ClientQueries;
using NUnit.Framework;
using System;

namespace MyCv.Application.Tests.CQRS.Queries
{
    [TestFixture]
    public class GetClientQueryValidationTests
    {
        private GetClientQueryValidation _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new GetClientQueryValidation();
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Empty()
        {
            // Arrange
            var query = new GetClientQuery { Id = Guid.Empty };

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorMessage("Id alanı boş geçilemez.");
        }

        [Test]
        public void Should_Have_Error_When_Id_Is_Invalid_Guid()
        {
            // Arrange
            var invalidGuid = new Guid("00000000-0000-0000-0000-000000000000"); // Geçersiz bir GUID değeri
            var query = new GetClientQuery { Id = invalidGuid };

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
            var query = new GetClientQuery { Id = validGuid };

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Test]
        public void Should_Have_Error_When_Name_Is_Too_Short()
        {
            // Arrange
            var query = new GetClientQuery { Name = "A" }; // İsim alanı 1 karakter

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("İsim alanı en az 2 karakter olmalıdır.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Name_Is_Valid()
        {
            // Arrange
            var query = new GetClientQuery { Name = "Alice" }; // İsim alanı 5 karakter

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_Have_Error_When_Surname_Is_Too_Short()
        {
            // Arrange
            var query = new GetClientQuery { Surname = "A" }; // Soyisim alanı 1 karakter

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Surname)
                .WithErrorMessage("Soyisim alanı en az 2 karakter olmalıdır.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Surname_Is_Valid()
        {
            // Arrange
            var query = new GetClientQuery { Surname = "Smith" }; // Soyisim alanı 5 karakter

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
        }

        [Test]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            // Arrange
            var query = new GetClientQuery { Email = "invalidemail" }; // Geçersiz e-posta formatı

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("Geçerli bir e-posta adresi giriniz.");
        }

        [Test]
        public void Should_Not_Have_Error_When_Email_Is_Valid()
        {
            // Arrange
            var query = new GetClientQuery { Email = "test@example.com" }; // Geçerli e-posta formatı

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Test]
        public void Should_Have_Error_When_PhoneNumber_Is_Invalid()
        {
            // Arrange
            var query = new GetClientQuery { PhoneNumber = "12345" }; // Geçersiz telefon numarası formatı

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PhoneNumber)
                .WithErrorMessage("Telefon numarası 10 haneli olmalıdır.");
        }

        [Test]
        public void Should_Not_Have_Error_When_PhoneNumber_Is_Valid()
        {
            // Arrange
            var query = new GetClientQuery { PhoneNumber = "1234567890" }; // Geçerli telefon numarası formatı

            // Act
            var result = _validator.TestValidate(query);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.PhoneNumber);
        }
    }
}
