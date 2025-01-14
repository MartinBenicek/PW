using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstractions
{
    public interface IProhlidkyService
    {
        List<ProhlidkyViewModel> GetProhlidky();
        void DeleteProhlidka(int id);
        void CreateProhlidka(ProhlidkyViewModel viewModel);
        ProhlidkyViewModel GetProhlidkaById(int id);
        void UpdateProhlidka(ProhlidkyViewModel viewModel);
    }
}
