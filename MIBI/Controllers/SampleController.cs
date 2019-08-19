namespace MIBI.Controllers
{
    using System.Linq;
    using System.Net;
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
        public IActionResult Post([FromBody]CreateNewSampleBindingModel bm)
        {
            var imgs = bm.Images;
            foreach (var img in imgs)
            {

            }

            return Ok();
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