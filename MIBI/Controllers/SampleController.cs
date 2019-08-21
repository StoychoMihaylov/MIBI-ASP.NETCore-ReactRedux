namespace MIBI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using MIBI.BindingModels;
    using MIBI.Services.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller
    {
        private ISamleService service;
        private IHostingEnvironment env;

        public SampleController(ISamleService service, IHostingEnvironment env)
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
            
            var name = Request.Headers["name"];
            var description = Request.Headers["description"];
            var tags = Request.Headers["tags"]
                .ToString()
                .Split(',')
                .Select(tag => tag.TrimStart(' ').TrimEnd(' '))
                .ToArray();

            var newSample = new
            {
                Name = name,
                Description = description,
                Tags = tags,
                Images = new List<string>()
            };

            try
            {
                foreach (var image in formData.Files)
                {
                    string path = Path.Combine(this.env.ContentRootPath + "\\Images");
                    var newImgName = Guid.NewGuid().ToString();
                    using (var img = new FileStream(Path.Combine(path, newImgName), FileMode.Create))
                    {
                        image.CopyToAsync(img);
                        newSample.Images.Add(newImgName);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }


            //TO DO: add new sample into the Database

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