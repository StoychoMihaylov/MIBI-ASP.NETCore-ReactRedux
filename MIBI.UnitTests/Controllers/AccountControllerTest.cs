namespace MIBI.UnitTests.Controllers
{
    using Moq;
    using Xunit;
    using System;
    using MIBI.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Services.Interfaces;
    using MIBI.Models.ViewModels.Account;
    using MIBI.Models.BindingModels.Account;
    using LoggerAPI.Interfaces;

    public class AccountControllerTest
    {
        [Fact]
        public void Post_RegisterAndLogin_ShouldReturnStatusCode201()
        {
            // Arrange
            var userId = "12354321-3123-1122-4332-123456789231";

            var bidingModel = new RegisterUserBindingModel()
            {
                Name = "Gosho",
                Email = "gosho@abv.bg",
                Password = "P@ssl0rd",
                ConfirmPassword = "P@ssl0rd"
            };
            var userCredentials = new AccountCredentialsViewModel()
            {
                UserId = new Guid(userId),
                Token = "Token-Token-Token"
            };

            var serviceMock = new Mock<IAccountService>();
            serviceMock
                .Setup(s => s.CreateNewUserAccount(bidingModel))
                .Returns(userCredentials);

            var loggerMock = new Mock<ILogger>();

            var controller = new AccountController(serviceMock.Object, loggerMock.Object);

            // Act
            var response = controller.RegisterAndLogin(bidingModel);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
            var result = response as OkObjectResult;
            var model = result.Value as AccountCredentialsViewModel;
            var modelId = model.UserId;
            Assert.Equal(new Guid(userId), modelId);
        }
    }
}
