using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaOrdinaceViewModel
    {
        public IList<LekarskaEvidenceViewModel>? LekarskaEvidences { get; set; }
        public IList<OrdinaceViewModel>? Ordinaces { get; set; }
    }
}
