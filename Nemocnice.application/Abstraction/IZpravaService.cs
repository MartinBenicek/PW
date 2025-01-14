using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstractions
{
    public interface IZpravaService
    {
        List<KartaLekarskaZprava> GetZpravy();
        List<KartaLekarskaZprava> SelectForUser(int userId);
        void DeleteZprava(int id);
        void CreateZprava(KartaLekarskaZprava viewModel);
        KartaLekarskaZprava GetZpravaById(int id);
        void UpdateZprava(KartaLekarskaZprava viewModel);
    }
}