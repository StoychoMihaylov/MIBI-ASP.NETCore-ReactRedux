﻿namespace MIBI.Services.Interfaces
{
    using System.Collections.Generic;
    using MIBI.Models.BindingModels;
    using MIBI.Models.ViewModels;

    public interface ISampleService
    {
        void CreateNewSample(NewSampleBidingModel newSample);
        List<AutocompleteBacteriaNamesViewModel> GetAllNamesOfSamples(string bacteriaName);
    }
}