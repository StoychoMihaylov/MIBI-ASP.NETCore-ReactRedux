namespace MIBI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Utilities;
    using MIBI.Services.Interfaces;
    using MIBI.Models.BindingModels.Account;
    using LoggerAPI.Interfaces;

    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService service;
        private ILogger logger;

        public AccountController(IAccountService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
        }

        // api/account/register
        [HttpPost]
        [Route("register")]
        public IActionResult RegisterAndLogin([FromBody] RegisterUserBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError("invalid model state on registrations");
                return BadRequest(ModelState);
            }

            if (bm.Password != bm.ConfirmPassword)
            {
                logger.LogError("incorrect password and confirm password on registrations");
                return BadRequest("Invalid credentials!");
            }

            var userAlreadyExist = this.service.CheckIfUserExist(bm);
            if (userAlreadyExist)
            {
                logger.LogError($"registration fail the user already exist");
                return BadRequest("User with this email already exist!");
            }

            var userCredentials = this.service.CreateNewUserAccount(bm); // User created, will return token(loged-in automaticaly)

            if (userCredentials == null)
            {
                logger.LogError("Error on registration token has been not returned");
                return new BadRequestResult();
            }

            logger.LogSuccess("User has been registered!");

            // created!
            return Ok(userCredentials);
        }

        // api/account/login
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginUserBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                logger.LogError($"invalid model state on log-in with email:{bm.Email}");
                return BadRequest(ModelState);
            }

            var userCredentials = this.service.LoginUser(bm);

            if (userCredentials == null)
            {
                logger.LogError($"wrong credentials on log-on with email:{bm.Email}");
                return BadRequest("Wrong credentials!");
            }

            logger.LogSuccess($"log-in with email:{bm.Email}");

            return Ok(userCredentials);
        }

        [HttpPost]
        [Authorize]
        [Route("logout")]
        public IActionResult Logout([FromBody] LogoutBindingModel bm)
        {
            try
            {
                this.service.DeleteUserToken(bm);
            }
            catch (Exception)
            {
                logger.LogError($"token for user with id:{bm.UserId} is not found on log-out");
                return NotFound();
            }

            logger.LogSuccess($"user with id:{bm.UserId} successful log-outed");
            
            return Ok();
        }
    }
}
