using Zenject;
using Arkham.Interactors;
using Arkham.EventData;

namespace Arkham.Presenters
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly IAddCardEvent addCardEvent;
        [Inject] private readonly IRemoveCardEvent removeCardEvent;
        [Inject] private readonly ISelectInvestigatorEvent selectInvestigatorEvent;
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly ICardsQuantityVisualizable cardsQuantityView;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.AddAction((_) => ChangeText());
            removeCardEvent.AddAction((_) => ChangeText());
            selectInvestigatorEvent.AddAction((_) => ChangeText());
        }

        /*******************************************************************/
        private void ChangeText()
        {
            cardsQuantityView.SetCardsAmount = currentInvestigator.AmountCardsSelected.ToString();
            cardsQuantityView.SetDeckSize = currentInvestigator.DeckSize.ToString();
        }
    }
}
