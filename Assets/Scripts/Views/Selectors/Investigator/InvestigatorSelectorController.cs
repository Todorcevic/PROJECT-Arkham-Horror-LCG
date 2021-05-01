﻿using Arkham.Model;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorSelectorController : IInvestigatorSelectorController
    {
        [Inject] private readonly RemoveInvestigatorEventDomain investigatorSelector;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly ChangeInvestigatorEventDomain investigatorChangeEvent;
        [Inject] private readonly IInvestigatorSelectorsManager investigatorSelectorManager;
        [Inject(Id = "MidZone")] private readonly RectTransform removeZone;

        /*******************************************************************/
        public void DoubleClicked(string investigatorId)
        {
            investigatorSelector.Remove(investigatorId);
            investigatorSelectEvent.SelectLead();
        }

        public void Clicked(string investigatorId) => investigatorSelectEvent.Select(investigatorId);

        public void Swaping(string investigatorId, int positionToSwap) => investigatorChangeEvent.Swap(positionToSwap, investigatorId);

        public void EndingDrag(string investigatorId, PointerEventData eventData)
        {
            if (IsInRemoveZone(eventData)) DoubleClicked(investigatorId);
            else investigatorSelectorManager.GetSelectorById(investigatorId).ArrangeAnimation();
        }

        private bool IsInRemoveZone(PointerEventData eventData) => eventData.hovered.Contains(removeZone.gameObject);
    }
}
