using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaZpravaPredpisViewModel
    {
        public LekarskaZpravaViewModel LekarskaZprava { get; set; }
        public PredpisViewModel Predpis { get; set; }
    }
}
