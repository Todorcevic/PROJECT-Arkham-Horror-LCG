using Arkham.Views;

namespace Arkham.Controllers
{
    public interface IViewInteractable
    {
        string Id { get; }
        IInteractableEffects InteractableEffects { get; }
    }
}
