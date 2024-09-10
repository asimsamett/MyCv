using FluentValidation.TestHelper;
using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Domain.Entities.Enums;

namespace UnitTestExample.ClientWriteUnitTest
{
    [TestFixture]
    public class CreateClientCommandValidatorTests
    {
        private CreateClientCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CreateClientCommandValidator();
        }

        [Test]
        public void Client_CorrectClientFormat_ValidClient()
        {
            // Arrange
            var clientCommand = new CreateClientCommand
            {
                Email = "�rnek@gmail.com",
                PhoneNumber = "1234567890",
                Address = "�stanbul",
                Name = "Name",
                Surname = "SurName",
                ClientFeature = new ClientFeaturesDto
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
            var clientCommand = new CreateClientCommand
            {
                Email = "�rnekgmail.com",
            };

            // Act
            var result = _validator.TestValidate(clientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Email).WithErrorMessage("Format uygun de�il");
        }

        [Test]
        public void createClientCommand_IncorrectPhoneNumberFormat_InvalidPhoneNumber()
        {
            // Arrange
            var clientCommand = new CreateClientCommand
            {
                PhoneNumber = "123"
            };

            // Act
            var result = _validator.TestValidate(clientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
                  .WithErrorMessage("Telefon Numaras� 10 Haneli Olmal�d�r");
        }

        [Test]
        public void createClientCommand_IncorrectAddressLength_InvalidLengthAddress()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                Address = new string('a', 201)
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Address)
                  .WithErrorMessage("max 50 karakter");
        }

        [Test]
        public void createClientCommand_IncorrectNameLength_InvalidMaxLengthName()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                Name = new string('a', 121)
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage("En fazla 120 karakter olmal�.");
        }

        [Test]
        public void createClientCommand_IncorrectSurnameLength_InvalidMaxLengthSurname()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                Surname = new string('a', 124)
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.Surname)
                  .WithErrorMessage("En fazla 120 karakter olmal�.");
        }

        [Test]
        public void createClientCommand_ClientFeatureIsNull_ShouldHaveError()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                ClientFeature = null
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.ClientFeature)
                  .WithErrorMessage("ClientFeature bo� olamaz.");
        }

        [Test]
        public void createClientCommand_ClientFeatureEducationIsEmpty_ShouldHaveError()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                ClientFeature = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: default,
                    referance: "samet"
                )
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.ClientFeature.Education)
                  .WithErrorMessage("E�itim bo� ge�ilemez");
        }

        [Test]
        public void createClientCommand_ClientFeaturePositionIsEmpty_ShouldHaveError()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                ClientFeature = new ClientFeaturesDto
                (
                    position: default,
                    education: Education.FullStack,
                    referance: "samet"
                )
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.ClientFeature.Position)
                  .WithErrorMessage("Pozisyon bo� ge�ilemez");
        }

        [Test]
        public void createClientCommand_ClientFeatureReferanceIsEmpty_ShouldHaveError()
        {
            // Arrange
            var createClientCommand = new CreateClientCommand
            {
                ClientFeature = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: Education.FullStack,
                    referance: ""
                )
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.ClientFeature.Referance)
                  .WithErrorMessage("Referans bo� ge�ilemez");
        }

        [Test]

        public void createClientCommand_ClientFeatureReferanceExceedsMaxLength_ShouldHaveError()
        {
            // Arrange

            var createClientCommand = new CreateClientCommand
            {
                ClientFeature = new ClientFeaturesDto
                (
                    position: Positions.Univercity,
                    education: Education.FullStack,
                    referance: new string('a', 51)
                )
            };

            // Act
            var result = _validator.TestValidate(createClientCommand);

            // Assert
            result.ShouldHaveValidationErrorFor(c => c.ClientFeature.Referance)
                  .WithErrorMessage("Maksimum 50 karakter olmal�.");
        }
    }
}
