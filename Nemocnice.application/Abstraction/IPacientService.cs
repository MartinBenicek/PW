using Nemocnice.application.ViewModels;

namespace Nemocnice.application.Abstraction
{
    public interface IPacientService
    {
        LekarskaOrdinaceViewModel GetLekarskaOrdinaceViewModel();
    }
}
