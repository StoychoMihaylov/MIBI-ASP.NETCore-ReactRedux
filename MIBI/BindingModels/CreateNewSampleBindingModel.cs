namespace MIBI.BindingModels
{
    using System.Collections.Generic;

    public class CreateNewSampleBindingModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SampleImageBindingModel> Images { get; set; }

        public ICollection<string> Tags { get; set; }
    }
}
