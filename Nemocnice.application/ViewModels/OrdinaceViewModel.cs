using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class OrdinaceViewModel
    {
        public int OrdinaceId { get; set; }
        public string? Budova { get; set; }
        public string? Mistnost { get; set; }
        public int DoktorId { get; set; }
    }
}
