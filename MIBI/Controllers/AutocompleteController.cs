namespace MIBI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AutocompleteController : Controller
    {
        private ISampleService service;

        public AutocompleteController(ISampleService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("names")]
        public IActionResult GetNames()
        {

            var bacteriaNames = this.service.GetAllNamesOfSamples();

            return Ok(bacteriaNames);
        }

        [HttpGet]
        [Route("tags")]
        public IActionResult GetTags()
        {
            var tags = this.service.GetAllTags();

            return Ok(tags);
        }

        [HttpGet]
        [Route("groups")]
        public IActionResult GetGroups()
        {
            var groups = this.service.GetAllGroups();

            return Ok(groups);
        }
    }
}