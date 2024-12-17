using Nemocnice.application.Abstraction;
using Nemocnice.application.ViewModels;
using Nemocnice.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.Implementation
{
    public class DoktorService : IDoktorService
    {
        private readonly ILekarskeSluzbyService _lekarskeSluzbyService;
        private readonly IOrdinaceService _ordinaceService;

        public DoktorService(ILekarskeSluzbyService lekarskeSluzbyService, IOrdinaceService ordinaceService)
        {
            _lekarskeSluzbyService = lekarskeSluzbyService;
            _ordinaceService = ordinaceService;
        }

        public LekarskeSluzbyViewModels GetLekarskeSluzbyViewModel()
        {
            var lekarskeSluzby = _lekarskeSluzbyService.Select();
            var ordinace = _ordinaceService.Select();

            return new LekarskeSluzbyViewModels
            {
                LekarskeSluzby = lekarskeSluzby,
                Ordinace = ordinace
            };
        }
    }
}
