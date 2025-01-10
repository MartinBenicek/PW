using Nemocnice.domain.Entities;

namespace Nemocnice.application.ViewModels
{
    public class LekarskeSluzbyViewModels
    {
        public IList<LekarskeSluzby>? LekarskeSluzby { get; set; }
        public IList<LekarskaZprava>? LekarskaZprava { get; set; }
        public IList<Predpis>? Predpis { get; set; }
        
        public IList<Ordinace>? Ordinace { get; set; }
    }
}
