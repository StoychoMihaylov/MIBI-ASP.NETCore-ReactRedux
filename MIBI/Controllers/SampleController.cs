namespace MIBI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MIBI.Models.BindingModels;
    using MIBI.Models.ViewModels;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller
    {
        private ISampleService service;
        private IHostingEnvironment env;

        public SampleController(ISampleService service, IHostingEnvironment env)
        {
            this.service = service;
            this.env = env;
        }

        [HttpPost]
        public IActionResult Post(
            [FromForm] string name,
            [FromForm] string description,
            [FromForm] string group,
            [FromForm] string tags,
            [FromForm]IFormCollection formData)
        {
            if (name == null
                && description == null
                && tags == null
                && group == null
                && formData == null)
            {
                return BadRequest("Please field up at least one image! All fields are requered!");
            }

            var sampleGroups = group
                .ToString()
                .Split(',')
                .Select(tag => tag.TrimStart(' ').TrimEnd(' '))
                .ToArray();

            var sampleTags = tags
                .ToString()
                .Split(',')
                .Select(tag => tag.TrimStart(' ').TrimEnd(' '))
                .ToArray();

            var newSaple = new NewSampleBidingModel()
            {
                Name = name,
                Description = description,
                Groups = sampleGroups,
                Tags = sampleTags,
                ImgUrls = new List<string>()
            };

            try
            {
                foreach (var image in formData.Files)
                {
                    var isImage = CheckIfFileIsAnImage(image);
                    if (! isImage)
                    {
                        return BadRequest("The file is not an image!");
                    }

                    string path = Path.Combine(this.env.ContentRootPath + "\\Images");
                    var newImgName = Guid.NewGuid().ToString() + (image.FileName.Substring(image.FileName.LastIndexOf('.')));
                    using (var img = new FileStream(Path.Combine(path, newImgName), FileMode.Create))
                    {
                        image.CopyToAsync(img);
                        newSaple.ImgUrls.Add(newImgName);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            try
            {
                this.service.CreateNewSample(newSaple);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        private bool CheckIfFileIsAnImage(IFormFile image)
        {
            if (image.ContentType == "image/jpg" 
                || image.ContentType == "image/jpeg"
                || image.ContentType == "image/png")
            {
                return true;
            }

            return false;
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