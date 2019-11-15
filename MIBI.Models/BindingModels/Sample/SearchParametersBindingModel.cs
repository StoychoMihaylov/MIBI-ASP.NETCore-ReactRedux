namespace MIBI.Models.BindingModels.Sample
{
    public class SearchParametersBindingModel
    {
        public string BacteriaName { get; set; }

        public string[] Tags { get; set; }

        public string[] Groups { get; set; }

        public string[] NutrientAgarPlates { get; set; }
    }
}
