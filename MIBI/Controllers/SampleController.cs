namespace MIBI.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Hosting;
    using MIBI.Utilities;
    using MIBI.Models.ViewModels;
    using MIBI.Services.Interfaces;
    using MIBI.Models.BindingModels;
    using MIBI.Models.BindingModels.Sample;

    [Route("api")]
    [Authorize]
    [ApiController]
    public class SampleController : Controller
    {
        private ISampleService service;
        private IHostingEnvironment env;
        private IAccountService accountService;

        public SampleController(ISampleService service, IHostingEnvironment env, IAccountService accountService)
        {
            this.service = service;
            this.accountService = accountService;
            this.env = env;
        }

        [HttpGet]
        [Route("sample/{id}")]
        public async Task<IActionResult> GetSampleById(string id)
        {
            if (id == null || id == "")
            {
                return BadRequest("Please provide sample id.");
            }

            var sample = await this.service.GetSampleById(id);

            if (sample == null)
            {
                return NotFound();
            }

            return Ok(sample);
        }

        [HttpGet]
        [Route("samples")]
        public IActionResult GetListOfSamples(SearchParametersBindingModel searchParams)
        {
            if (searchParams.BacteriaName == null &&
                searchParams.Tags == null && 
                searchParams.Groups == null &&
                searchParams.NutrientAgarPlates == null)
            {
                return BadRequest("No search params has been sent.");
            }

            var sampleViewModels = this.service.GetAllSamplesByGivenSearchParams(searchParams);

            return Ok(sampleViewModels);
        }

        [HttpPost]
        [Route("sample")]
        public async Task<IActionResult> CreateNewSample(
            [FromForm] string name,
            [FromForm] string description,
            [FromForm] string groups,
            [FromForm] string tags,
            [FromForm] string nutrientAgarPlates,
            [FromForm]IFormCollection formData)
        {
            if (name == null
                && description == null
                && tags == null
                && groups == null
                && formData == null
                && nutrientAgarPlates == null)
            {
                return BadRequest("Please field up at least one image! All fields are requered!");
            }

            var user = this.accountService
                .RetrieveCurrentUser(this.Request.Headers["Authorization"]);

            var newSample = new NewSampleBidingModel()
            {
                Name = name,
                Description = description,
                Groups = groups,
                Tags = tags,
                NutrientAgarPlates = nutrientAgarPlates,
                ImgUrls = new List<string>()
            };

            try
            {
                await SaveImages(formData, newSample);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            try
            {
                this.service.CreateNewSample(newSample, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        private async Task SaveImages(IFormCollection formData, NewSampleBidingModel newSample)
        {
            foreach (var image in formData.Files)
            {
                var isImage = CheckIfFileIsAnImage(image);
                if (!isImage)
                {
                    throw new Exception("Allowed image format is image/jpg(jpeg).");
                }

                try
                {
                    string path = Path.Combine(this.env.ContentRootPath + "\\wwwroot\\Images");
                    var newImgName = Guid.NewGuid().ToString() + (image.FileName.Substring(image.FileName.LastIndexOf('.')));
                    using (var img = new FileStream(Path.Combine(path, newImgName), FileMode.Create))
                    {
                        await image.CopyToAsync(img);
                        newSample.ImgUrls.Add(newImgName);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        private bool CheckIfFileIsAnImage(IFormFile image)
        {
            if (image.ContentType == "image/jpg" || image.ContentType == "image/jpeg")
            {
                return true;
            }

            return false;
        }

        [HttpPut]
        [Route("sample")]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("sample")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}