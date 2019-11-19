namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Models.ViewModels.AutocompleateSuggestions;

    public interface IAutocompleteService
    {
        List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples();
        List<TagViewModel> GetAllTags();
        List<GroupViewModel> GetAllGroups();
        List<NutrientAgarPlateViewModel> GetAllNutrientAgarPlates();
    }
}
