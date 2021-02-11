namespace Arkham.Controllers
{
    public interface IDoubleClickController
    {
        void DoubleClick(string objectView, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
