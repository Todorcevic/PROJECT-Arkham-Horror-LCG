using Arkham.Model;
using System.Linq;
using UnityEngine;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CardsSelectedPresenter : IInitializable
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly ICardAddPresenter addCard;
        [Inject] private readonly InvestigatorRepository investigatorManager;

        /*******************************************************************/
        public void Initialize() => investigatorSelectEvent.Subscribe(ShowAllCards);

        /*******************************************************************/
        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            if (investigatorId == null) return;
            foreach (string cardId in investigatorManager.Get(investigatorId).FullDeck.Select(c => c.Code))
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
