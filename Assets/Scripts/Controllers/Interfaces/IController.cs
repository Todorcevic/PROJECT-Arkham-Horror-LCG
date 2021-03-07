namespace Arkham.Controllers
{
    public interface IController
    {
        void Click(IViewInteractable viewInteractable);
        void DoubleClick(IViewInteractable viewInteractable);
        void HoverOn(IViewInteractable viewInteractable);
        void HoverOff(IViewInteractable viewInteractable);
    }
}
