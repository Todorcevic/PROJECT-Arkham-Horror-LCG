using Arkham.Views;

namespace Arkham.Presenters
{
    public interface IClickPresenter<in A> : IPresenter<A>
    {
        void Click(A objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
