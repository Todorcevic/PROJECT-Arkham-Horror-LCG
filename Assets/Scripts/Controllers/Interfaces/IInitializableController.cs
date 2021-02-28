using Arkham.Views;

namespace Arkham.Controllers
{
    public interface IInitializableController
    {
        void Init(IInteractableView campaignView);
    }
}
