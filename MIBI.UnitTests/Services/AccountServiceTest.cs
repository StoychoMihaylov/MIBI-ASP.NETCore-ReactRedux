namespace MIBI.UnitTests.Services
{
    using System;
    using Xunit;
    using System.Linq;
    using MIBI.Data.Context;
    using MIBI.Data.Entities;
    using MIBI.Models.BindingModels.Account;
    using MIBI.Models.ViewModels.Account;
    using MIBI.Services.Services;
    using Microsoft.EntityFrameworkCore;
    

    public class AccountServiceTest
    {
        [Fact]
        public void CreateNewUserAccount_CalledWithCorrectInputData_ShouldReturnTrueAndUserCreated()
        {
            // Arrange
            var createdUser = new User();
            var db = this.GetDatabase();
            var service = new AccountService(db);

            RegisterUserBindingModel bm = new RegisterUserBindingModel()
            {
                Name = "Gosho",
                Email = "gosho@abv.bg",
                Password = "P@ssl0rd",
                ConfirmPassword = "P@ssl0rd"
            };

            // Act
            var tokenResponse = service.CreateNewUserAccount(bm);
            if (tokenResponse != null)
            {
                // Check if user is created.
                createdUser = db.Users.Single();
            }

            // Assert
            Assert.NotNull(createdUser);
            var userId = tokenResponse.UserId;
            Assert.IsType<Guid>(userId);
            Assert.NotEqual(0, userId.ToString().Length);
        }

        [Fact]
        public void LoginUser_CalledWithRelevantInputData_ShouldReturnTokenBearer()
        {
            // Arrange
            var userCredentials = new AccountCredentialsViewModel();
            var db = this.GetDatabase();
            var service = new AccountService(db);

            RegisterUserBindingModel bm = new RegisterUserBindingModel()
            {
                Name = "Gosho",
                Email = "gosho@abv.bg",
                Password = "P@ssl0rd",
                ConfirmPassword = "P@sslord"
            };

            LoginUserBindingModel loginForm = new LoginUserBindingModel()
            {
                Email = "gosho@abv.bg",
                Password = "P@ssl0rd"
            };

            // Act
            // Case with Correct Password Input
            var isUserCreated = service.CreateNewUserAccount(bm);
            if (isUserCreated != null)
            {
                userCredentials = service.LoginUser(loginForm);
            }

            // Assert
            Assert.NotNull(userCredentials);
            var userId = userCredentials.UserId;
            Assert.IsType<Guid>(userId);
            Assert.NotEqual(0, userId.ToString().Length);
        }

        private MIBIContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<MIBIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Microsoft.EntityFrameworkCore.InMemory
                .Options;

            return new MIBIContext(dbOptions);
        }
    }
}
