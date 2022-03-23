﻿using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class DeckCardView : CardView, IPointerClickHandler
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;
        [Title("DECKCARD RESOURCES")]
        [SerializeField, Required, ChildGameObjectsOnly] private TextMeshProUGUI textQuantity;
        [SerializeField, Required, ChildGameObjectsOnly] private TokenView xpCost;

        public override bool MustReshow => true;

        /*******************************************************************/
        void IPointerClickHandler.OnPointerClick(PointerEventData eventData) => PointerClick();

        public void SetQuantity(int quantity) => textQuantity.text = FormatQuantity(quantity);

        public void SetXpCost(int quantity) => xpCost.UpdateAmount(quantity);

        private void PointerClick()
        {
            audioInteractable.ClickSound();
            if (IsInactive) CantAdd();
            else addCardUseCase.AddCard(Id, investigatorSelectorManager.InvestigatorSelected);
        }

        private string FormatQuantity(int quantity) => quantity > 1 ? "x" + quantity : string.Empty;
    }
}