﻿using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstractions
{
    public interface IPredpisService
    {
        List<LekarskaZpravaPredpisViewModel> GetPredpisy();
        List<LekarskaZpravaPredpisViewModel> SelectForUser(int userId);
        List<LekarskaZpravaPredpisViewModel> SelectForDoctor(int doctorId);
        void DeletePredpis(int id);
        void CreatePredpis(PredpisViewModel viewModel);
        PredpisViewModel GetPredpisById(int id);
        void UpdatePredpis(PredpisViewModel viewModel);
    }
}