namespace MIBI.Controllers
{
    using MIBI.BindingModels;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller
    {
        private ISamleService service;

        public SampleController(ISamleService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It works!");
        }

        [HttpPost]
        public IActionResult Post(CreateNewSampleBindingModel bm)
        {
            var obj = new [] { "fdd", "fdfd", "fdfdfd" };

            return Ok(obj);
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}