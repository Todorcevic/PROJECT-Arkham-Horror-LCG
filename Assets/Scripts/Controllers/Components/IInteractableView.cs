using Zenject;

namespace Arkham.Controllers
{
    public interface IInteractableView
    {
        string Id { get; }
        InteractableComponent Interactable { get; }
    }
}
