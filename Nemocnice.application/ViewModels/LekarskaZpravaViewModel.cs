using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaZpravaViewModel
    {
        public int LekarskaZpravaId { get; set; }
        public string? Zprava { get; set; }
        public DateTime? Datum { get; set; }
        public int KartaId { get; set; }
    }
}
