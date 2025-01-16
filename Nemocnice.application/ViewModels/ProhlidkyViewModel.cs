using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.application.ViewModels
{
    public class ProhlidkyViewModel
    {
        public KartaViewModel Karta { get; set; }
        public OrdinaceViewModel Ordinace { get; set; }
        public LekarskeSluzbyViewModel LekarskeSluzby { get; set; }
        public string? OrdinaceImageSrc { get; set; }
    }
}
