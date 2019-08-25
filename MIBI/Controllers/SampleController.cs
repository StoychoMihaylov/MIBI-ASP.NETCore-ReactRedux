namespace MIBI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MIBI.Models.BindingModels;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It works!");
        }

        [HttpPost]
        public IActionResult Post(IFormCollection formData)
        {
            if (Request.Headers["name"] == "" 
                && Request.Headers["description"] == "" 
                && Request.Headers["tags"] == ""
                && formData == null)
            {
                return BadRequest("At least one image and all fields are requered!");
            }
            
            var name = Request.Headers["name"];
            var description = Request.Headers["description"];
            var group = Request.Headers["group"];
            var tags = Request.Headers["tags"]
                .ToString()
                .Split(',')
                .Select(tag => tag.TrimStart(' ').TrimEnd(' '))
                .ToArray();

            var newSaple = new NewSampleBidingModel(){
                Name = name,
                Description = description,
                Group = group,
                Tags = tags,
                ImgUrls = new List<string>()
            };

            try
            {
                foreach (var image in formData.Files)
                {
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
            
            this.service.CreateNewSample(newSaple);

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