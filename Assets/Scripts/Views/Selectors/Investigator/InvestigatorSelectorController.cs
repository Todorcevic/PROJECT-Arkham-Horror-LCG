using Arkham.Interactors;
using Arkham.Repositories;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly IInvestigatorSelectorRepository investigatorSelectorRepository;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;

        /*******************************************************************/
        public void DoubleClicked(string investigatorId)
        {
            investigatorSelectorRepository.Remove(investigatorId);
            investigatorSelectorRepository.SelectLead();
        }

        public void Clicked(string investigatorId) => investigatorSelectorRepository.SelectCurrent(investigatorId);

        public void Swaping(string investigatorId, int positionToSwap) => investigatorSelectorRepository.Swap(positionToSwap, investigatorId);

        public void EndingDrag(string investigatorId, PointerEventData eventData)
        {
            if (IsInRemoveZone(eventData)) DoubleClicked(investigatorId);
            else investigatorSelectorManager.GetSelectorById(investigatorId).ArrangeAnimation();
        }

        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);
    }
}
