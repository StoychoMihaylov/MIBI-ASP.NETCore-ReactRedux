namespace MIBI.BindingModels
{
    using System.Collections.Generic;

    public class CreateNewSampleBindingModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Base64Images { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
