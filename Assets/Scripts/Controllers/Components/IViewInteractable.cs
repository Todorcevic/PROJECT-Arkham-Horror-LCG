using Zenject;

namespace Arkham.Controllers
{
    public interface IViewInteractable
    {
        string Id { get; }
        InteractableComponent Interactable { get; }
    }
}
