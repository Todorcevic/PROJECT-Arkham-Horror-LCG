using Arkham.EventData;
using Arkham.Interactors;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardsSelectedUseCase : IInitializable
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInfoInteractor;
        [Inject] private readonly IAddCardUseCase addCard;

        /*******************************************************************/
        public void Initialize() => selectInvestigatorEvent.AddAction(ShowAllCards);

        /*******************************************************************/
        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            if (investigatorId == null) return;
            foreach (string cardId in investigatorInfoInteractor.GetFullDeck(investigatorId))
                addCard.SetCardInSelector(cardId);
        }

        private void CleanAllSelectors()
        {
            foreach (CardSelectorView selector in cardSelectorsManager.GetAllFilledSelectors())
                DesactivateSelector(selector);
        }

        private void DesactivateSelector(CardSelectorView selector)
        {
            selector.SetSelector(null);
            selector.SetTransform(selectorsZone);
        }
    }
}
