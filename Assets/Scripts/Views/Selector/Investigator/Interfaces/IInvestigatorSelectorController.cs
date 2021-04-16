namespace Arkham.Views
{
    public interface IInvestigatorSelectorController
    {
        void Removing(string investigatorId);
        void Selecting(string investigatorId);
        void Swaping(string investigatorId, int positionToSwap);
        void EndingDrag(string investigatorId, UnityEngine.EventSystems.PointerEventData eventData);
    }
}
