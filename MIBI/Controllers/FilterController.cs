namespace MIBI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MIBI.Utilities;
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Services.Interfaces;

    [Route("api/filter")]
    [Authorize]
    [ApiController]
    public class FilterController : Controller
    {
        private IAutocompleteService service;

        public FilterController(IAutocompleteService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("names")]
        public IActionResult GetSampleNames()
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

        [HttpGet]
        [Route("nutrientAgarPlates")]
        public IActionResult GetNutrientAgarPlates()
        {
            var nutrientAgarPlates = this.service.GetAllNutrientAgarPlates();

            return Ok(nutrientAgarPlates);
        }
    }
}