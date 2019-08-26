namespace MIBI.Models.BindingModels
{
    using System.Collections.Generic;

    public class NewSampleBidingModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string[] Groups {get; set;}

        public string[] Tags { get; set; }

        public List<string> ImgUrls { get; set; }
    }
}
