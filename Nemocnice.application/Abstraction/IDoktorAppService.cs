using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstraction
{
    public interface IDoktorService
    {
        LekarskeSluzbyViewModels GetLekarskeSluzbyViewModel();
    }
}