using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Abstraction
{
    public interface IOrdinaceService
    {
        List<OrdinaceViewModel> GetOrdinace();
        OrdinaceViewModel GetOrdinaceById(int id);
        void CreateOrdinace(OrdinaceViewModel viewModel);
        void UpdateOrdinace(OrdinaceViewModel viewModel);
        void DeleteOrdinace(int id);
    }
}