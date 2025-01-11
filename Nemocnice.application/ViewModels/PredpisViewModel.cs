using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class PredpisViewModel
    {
        public int Id { get; set; }
        public string? TypLeku { get; set; }
        public string? NazevLeku { get; set; }
        public string? CasPodani { get; set; }
    }
}
