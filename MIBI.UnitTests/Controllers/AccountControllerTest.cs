namespace MIBI.UnitTests.Controllers
{
    using Moq;
    using Xunit;
    using System;
    using Microsoft.AspNetCore.Mvc; 
    using MIBI.Controllers;
    using MIBI.Models.BindingModels.Account;
    using MIBI.Models.ViewModels.Account;
    using MIBI.Services.Interfaces;
  

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
            var userCredentials = new AccountCredentialsViewModel()
            {
                UserId = new Guid("12354321-3123-1122-4332-123456789231"),
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
            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response);
            var result = response as OkObjectResult;
            var model = result.Value as AccountCredentialsViewModel;
            var userId = model.UserId;
            Assert.Equal(new Guid("12354321-3123-1122-4332-123456789231"), userId);
        }
    }
}
