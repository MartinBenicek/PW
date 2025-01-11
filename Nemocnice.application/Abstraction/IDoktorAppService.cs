using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstraction
{
    public interface IDoktorService
    {
        LekarskaOrdinaceViewModel GetLekarskaOrdinaceViewModel();
    }
}