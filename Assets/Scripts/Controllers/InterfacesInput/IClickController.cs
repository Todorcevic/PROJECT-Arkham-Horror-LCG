namespace Arkham.Controllers
{
    public interface IClickController
    {
        void Click(string id, UnityEngine.EventSystems.PointerEventData eventData = null);
    }
}
