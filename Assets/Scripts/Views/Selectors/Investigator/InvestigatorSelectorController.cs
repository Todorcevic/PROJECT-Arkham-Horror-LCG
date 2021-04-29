using Arkham.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly InvestigatorSelectorEventDomain investigatorSelector;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;

        /*******************************************************************/
        public void DoubleClicked(string investigatorId)
        {
            investigatorSelector.Remove(investigatorId);
            investigatorSelector.SelectLead();
        }

        public void Clicked(string investigatorId) => investigatorSelector.SelectCurrentOrLead();

        public void Swaping(string investigatorId, int positionToSwap) => investigatorSelector.Swap(positionToSwap, investigatorId);

        public void EndingDrag(string investigatorId, PointerEventData eventData)
        {
            if (IsInRemoveZone(eventData)) DoubleClicked(investigatorId);
            else investigatorSelectorManager.GetSelectorById(investigatorId).ArrangeAnimation();
        }

        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);
    }
}
