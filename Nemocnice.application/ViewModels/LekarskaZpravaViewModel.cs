using Nemocnice.domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaZpravaViewModel
    {
        public int? LekarskaZpravaId { get; set; }
        public string? Zprava { get; set; }

        [FutureDate]
        public DateTime Datum { get; set; } = DateTime.Now;
        public int? KartaId { get; set; }
    }
}
