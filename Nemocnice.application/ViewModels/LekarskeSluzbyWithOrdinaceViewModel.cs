using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskeSluzbyWithOrdinaceViewModel
    {
        public int Id { get; set; }
        public string? Ukon { get; set; }
        public string? Ockovani { get; set; }
        public string? Vysetreni { get; set; }
        public DateTime Datum { get; set; }
        public string? Budova { get; set; }
        public string? Mistnost { get; set; }
    }
}
