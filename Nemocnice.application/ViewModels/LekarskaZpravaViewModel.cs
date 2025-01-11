using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class LekarskaZpravaViewModel
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public string? Zprava { get; set; }
    }
}
