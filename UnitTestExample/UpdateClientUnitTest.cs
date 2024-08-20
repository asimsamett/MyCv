using FluentValidation.TestHelper;
using MyCv.Application.CQRS.Command;
using MyCv.Domain.Entities.Enums;

namespace UnitTestExample.UpdateClientUnitTest
{
    [TestFixture]
    public class UpdateClientCommandValidatorTests
    {
        private UpdateClientCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new UpdateClientCommandValidator();
        }

        [Test]
        public void Client_CorrectClientFormat_ValidClient()
        {
            // Arrange
            var clientCommand = new UpdateClientCommand
            {
                Email = "örnek@gmail.com",
                PhoneNumber = "1234567890",
                Address = "İstanbul",
                Name = "Name",
                Surname = "SurName",
                UpdateClientFeatures = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: Education.FullStack,
                    referance: "samet"
                )
            };

            // Act
            var result = _validator.TestValidate(clientCommand);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Test]
        public void createClientCommand_IncorrectEmailFormat_InvalidEmail()
        {
            // Arrange
            var client = new UpdateClientCommand
            {
                Email = "örnekgmail.com",
            };

            // Act
            var result = _validator.TestValidate(client);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email).WithErrorMessage("Format uygun değil");
        }

        [Test]
        public void createClientCommand_IncorrectPhoneNumberFormat_InvalidPhoneNumber()
        {
            // Arrange
            var clientCommand = new UpdateClientCommand
            {
                PhoneNumber = "123"
            };

            // Act
            var result = _validator.TestValidate(clientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
                  .WithErrorMessage("Telefon Numarası 10 Haneli Olmalıdır");
        }

        [Test]
        public void createClientCommand_IncorrectAddressLength_InvalidLengthAddress()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                Address = new string('a', 201)
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Address)
                  .WithErrorMessage("max 50 karakter");
        }

        [Test]
        public void createClientCommand_IncorrectNameLength_InvalidMaxLengthName()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                Name = new string('a', 121)
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage("En fazla 120 karakter olmalı.");
        }

        [Test]
        public void createClientCommand_IncorrectSurnameLength_InvalidMaxLengthSurname()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                Surname = new string('a', 124)
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Surname)
                  .WithErrorMessage("En fazla 120 karakter olmalı.");
        }

        [Test]
        public void createClientCommand_ClientFeatureIsNull_ShouldHaveError()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                UpdateClientFeatures = null
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.UpdateClientFeatures)
                  .WithErrorMessage("ClientFeature boş olamaz.");
        }

        [Test]
        public void createClientCommand_ClientFeatureEducationIsEmpty_ShouldHaveError()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                UpdateClientFeatures = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: default,
                    referance: "samet"
                )
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.UpdateClientFeatures.Education)
                  .WithErrorMessage("Eğitim boş geçilemez");
        }

        [Test]
        public void createClientCommand_ClientFeaturePositionIsEmpty_ShouldHaveError()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                UpdateClientFeatures = new ClientFeaturesDto
                (
                    position: default,
                    education: Education.FullStack,
                    referance: "samet"
                )
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.UpdateClientFeatures.Position)
                  .WithErrorMessage("Pozisyon boş geçilemez");
        }

        [Test]
        public void createClientCommand_ClientFeatureReferanceIsEmpty_ShouldHaveError()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                UpdateClientFeatures = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: Education.FullStack,
                    referance: ""
                )
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.UpdateClientFeatures.Referance)
                  .WithErrorMessage("Referans boş geçilemez");
        }

        [Test]
        public void createClientCommand_ClientFeatureReferanceExceedsMaxLength_ShouldHaveError()
        {
            // Arrange
            var updateClientCommand = new UpdateClientCommand
            {
                UpdateClientFeatures = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: Education.FullStack,
                    referance: new string('a', 51)
                )
            };

            // Act
            var result = _validator.TestValidate(updateClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.UpdateClientFeatures.Referance)
                  .WithErrorMessage("Maksimum 50 karakter olmalı.");
        }
    }
}
