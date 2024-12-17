using Nemocnice.domain.Entities;

namespace Nemocnice.application.ViewModels.cs
{
    public class LekarskeSluzbyViewModels
    {
        public IList<LekarskeSluzby>? LekarskeSluzby { get; set; }
        public IList<Ordinace>? Ordinace { get; set; }
    }
}
