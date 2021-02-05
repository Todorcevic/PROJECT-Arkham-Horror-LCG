namespace Arkham.Presenters
{
    public interface IFullInteractablePresenter<in A> : IClickPresenter<A>
    {
        void HoverOn(A objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
        void HoverOff(A objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
