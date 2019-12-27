namespace MIBI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MIBI.Services.Interfaces;
    using MIBI.Utilities;
    using LoggerAPI.Interfaces;

    [Route("api/filter")]
    [Authorize]
    [ApiController]
    public class FilterController : Controller
    {
        private IAutocompleteService service;
        private ILogger logger;

        public FilterController(IAutocompleteService service, ILogger logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        [Route("names")]
        public IActionResult GetSampleNames()
        {
            logger.LogInfo("get all samples names");
            var bacteriaNames = this.service.GetAllNamesOfSamples();

            if (bacteriaNames == null || bacteriaNames.Count() == 0)
            {
                logger.LogError("samples names are not found");
                return NotFound();
            }

            logger.LogSuccess("get all samples names");

            return Ok(bacteriaNames);
        }

        [HttpGet]
        [Route("tags")]
        public IActionResult GetTags()
        {
            logger.LogInfo("get all tags");
            var tags = this.service.GetAllTags();

            if (tags == null || tags.Count() == 0)
            {
                logger.LogError("tags are not found");
                return NotFound();
            }

            logger.LogSuccess("get all tags");

            return Ok(tags);
        }

        [HttpGet]
        [Route("groups")]
        public IActionResult GetGroups()
        {
            logger.LogInfo("get all groups");
            var groups = this.service.GetAllGroups();

            if (groups == null || groups.Count() == 0)
            {
                logger.LogError("groups are not found");
                return NotFound();
            }

            logger.LogSuccess("get all groups");

            return Ok(groups);
        }

        [HttpGet]
        [Route("nutrientAgarPlates")]
        public IActionResult GetNutrientAgarPlates()
        {
            var nutrientAgarPlates = this.service.GetAllNutrientAgarPlates();

            if (nutrientAgarPlates == null || nutrientAgarPlates.Count() == 0)
            {
                logger.LogError("nutrient agar plates are not found");
                return NotFound();
            }

            logger.LogSuccess("get all nutrient agar plates");

            return Ok(nutrientAgarPlates);
        }
    }
}