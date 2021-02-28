namespace Arkham.Views
{
    public interface IInteractableView
    {
        string Id { get; }
        InteractableComponent Interactable { get; }
    }
}
