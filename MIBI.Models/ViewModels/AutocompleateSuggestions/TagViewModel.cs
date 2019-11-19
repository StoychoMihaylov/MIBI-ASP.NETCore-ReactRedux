namespace MIBI.Models.ViewModels.AutocompleateSuggestions
{
    using System;

    public class TagViewModel
    {
        public Guid Id { get; set; }

        public string IconUrl { get; set; }

        public string Category { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }
    }
}
