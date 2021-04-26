using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    public class CardsSelectedPresenter : IInitializable
    {
        [Inject(Id = "CardSelectorZone")] public RectTransform selectorsZone;
        [Inject] private readonly IInvestigatorSelectedEvent selectInvestigatorEvent;
        [Inject] private readonly ICardSelectorsManager cardSelectorsManager;
        [Inject] private readonly ICardAddPresenter addCard;

        [Inject] private readonly IInvestigatorInfo investigatorRepository;
        /*******************************************************************/
        public void Initialize() => selectInvestigatorEvent.Subscribe(ShowAllCards);

        /*******************************************************************/
        private void ShowAllCards(string investigatorId)
        {
            CleanAllSelectors();
            if (investigatorId == null) return;
            foreach (string cardId in investigatorRepository.Get(investigatorId).FullDeck)
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
