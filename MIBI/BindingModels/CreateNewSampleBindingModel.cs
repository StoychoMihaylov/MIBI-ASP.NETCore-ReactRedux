namespace MIBI.BindingModels
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;

    public class CreateNewSampleBindingModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormCollection Images { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
