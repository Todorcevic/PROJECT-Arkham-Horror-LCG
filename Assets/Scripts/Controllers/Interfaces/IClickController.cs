namespace Arkham.Controllers
{
    public interface IClickController<in T>
    {
        void Click(T objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
