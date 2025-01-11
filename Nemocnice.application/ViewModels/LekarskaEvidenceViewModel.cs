using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaEvidenceViewModel
    {
        public IList<LekarskeSluzbyViewModel>? LekarskeSluzbies{ get; set; }
        public IList<PredpisViewModel>? Prepises{ get; set; }
        public IList<LekarskaZpravaViewModel>? LekarskaZpravas{ get; set; }
    }
}
