namespace Arkham.Controllers
{
    public interface IDoubleClickController<in T>
    {
        void DoubleClick(T objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
