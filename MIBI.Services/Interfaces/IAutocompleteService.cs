namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Data.Entities;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public interface IAutocompleteService
    {
        List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples();
        List<Tag> GetAllTags();
        List<GroupViewModel> GetAllGroups();
        List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates();
    }
}
