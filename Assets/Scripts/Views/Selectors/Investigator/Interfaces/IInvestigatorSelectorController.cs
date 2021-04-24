namespace Arkham.View
{
    public interface IInvestigatorSelectorController
    {
        void DoubleClicked(string investigatorId);
        void Clicked(string investigatorId);
        void Swaping(string investigatorId, int positionToSwap);
        void EndingDrag(string investigatorId, UnityEngine.EventSystems.PointerEventData eventData);
    }
}
