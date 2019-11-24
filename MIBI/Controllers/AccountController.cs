namespace MIBI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Services.Interfaces;
    using MIBI.Models.BindingModels.Account;

    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        // api/account/register
        [HttpPost]
        [Route("register")]
        public IActionResult RegisterAndLogin(RegisterUserBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (bm.Password != bm.ConfirmPassword)
            {
                return BadRequest("Invalid credentials!");
            }

            var userCredentials = this.service.CreateNewUserAccount(bm);

            if (userCredentials == null)
            {
                return new BadRequestResult();
            }

            // created!
            return Ok(userCredentials);
        }

        // api/account/login
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUserBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCredentials = this.service.LoginUser(bm);

            if (userCredentials == null)
            {
                return BadRequest("Wrong credentials!");
            }

            return Ok(userCredentials);
        }
    }
}
