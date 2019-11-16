namespace MIBI.UnitTests.Controllers
{
    using Xunit;
    using Microsoft.AspNetCore.Mvc;
    
    using MIBI.Controllers;
    using MIBI.Models.BindingModels.Account;
    using MIBI.Models.ViewModels.Account;
    using MIBI.Services.Interfaces;
    using System;
    using Moq;

    public class AccountControllerTest
    {
        [Fact]
        public void Post_RegisterAndLogin_ShouldReturnStatusCode201()
        {
            // Arrange
            var bidingModel = new RegisterUserBindingModel()
            {
                Name = "Gosho",
                Email = "gosho@abv.bg",
                Password = "P@ssl0rd",
                ConfirmPassword = "P@ssl0rd"
            };
            var userCredentials = new AccountLoginViewModel()
            {
                UserId = new Guid(),
                Token = "Token-Token-Token"
            };

            var serviceMock = new Mock<IAccountService>(); // Using Moq to mock the service
            serviceMock
                .Setup(s => s.CreateNewUserAccount(bidingModel))
                .Returns(userCredentials);

            var controller = new AccountController(serviceMock.Object);

            // Act
            var response = controller.RegisterAndLogin(bidingModel);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
