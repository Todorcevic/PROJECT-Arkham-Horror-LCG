using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly RemoveCardEventDomain removeCardEvent;
        [Inject] private readonly InvestigatorSelectorEventDomain selectInvestigatorEvent;
        [Inject] private readonly CurrentInvestigatorInteractor currentInvestigator;
        [Inject] private readonly CardsQuantityView cardsQuantityView;

        private string AmountCards => currentInvestigator.Info?.AmountCardsSelected.ToString();
        private string DeckSize => currentInvestigator.Info?.DeckSize.ToString();

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.DeckCardAdded += (_) => UpdateData();
            removeCardEvent.DeckCardRemoved += (_) => UpdateData();
            selectInvestigatorEvent.Select((_) => UpdateData());
        }

        /*******************************************************************/
        private void UpdateData()
        {
            cardsQuantityView.SetCardsAmount(AmountCards);
            cardsQuantityView.SetDeckSize(DeckSize);
        }
    }
}
