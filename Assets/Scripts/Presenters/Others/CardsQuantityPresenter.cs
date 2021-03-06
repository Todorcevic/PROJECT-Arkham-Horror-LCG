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
        [Inject] private readonly ICurrentInvestigator currentInvestigator;
        [Inject] private readonly ICardsQuantityVisualizable cardsQuantityView;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.DeckCardAdded += ChangeText;
            removeCardEvent.DeckCardRemoved += ChangeText;
            selectInvestigatorEvent.InvestigatorSelectedChanged += ChangeText;
        }

        /*******************************************************************/
        private void ChangeText(string _)
        {
            cardsQuantityView.SetCardsAmount = currentInvestigator.AmountCardsSelected.ToString();
            cardsQuantityView.SetDeckSize = currentInvestigator.DeckSize.ToString();
        }
    }
}
