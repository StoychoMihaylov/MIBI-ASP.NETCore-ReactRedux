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
            return View();
        }

        [HttpPost]
        public IActionResult Post(CreateNewSampleBindingModel bm)
        {
            return View();
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete()
        {
            return View();
        }
    }
}