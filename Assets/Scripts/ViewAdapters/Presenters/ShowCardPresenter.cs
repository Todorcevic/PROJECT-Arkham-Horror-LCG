using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Managers;
using Arkham.Views;
using Zenject;

namespace Arkham.Presenters
{
    public class ShowCardPresenter : IInitializable
    {
        [Inject] private readonly IShowCard showCard;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly IAddInvestigatorEvent addInvestigatorEvent;
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;

        /*******************************************************************/
        public void Initialize()
        {
            addInvestigatorEvent.AddAction(AddInvestigator);
            addCardEvent.AddAction(AddCard);
            removeCardEvent.AddAction(RemoveCard);
        }

        private void AddInvestigator(string InvestigatorId) => showCard.HidePreviewCard();

        private void AddCard(string cardId) => showCard.AddMoveAnimation();

        private void RemoveCard(string cardId)
        {
            bool withReshow = currentInvestigator.GetAmountOfThisCardInDeck(cardId) > 0;
            showCard.RemoveMoveAnimation(withReshow);
        }
    }
}
