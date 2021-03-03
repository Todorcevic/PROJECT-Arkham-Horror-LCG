using Zenject;
using Arkham.Interactors;

namespace Arkham.Presenters
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ICardsQuantityVisualizable cardsQuantity;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            deckBuilderInteractor.DeckCardAdded += ChangeText;
            deckBuilderInteractor.DeckCardRemoved += ChangeText;
            investigatorSelectorInteractor.InvestigatorSelectedChanged += ChangeText;
            ChangeText(null);
        }

        /*******************************************************************/
        private void ChangeText(string _)
        {
            cardsQuantity.SetCardsAmount = deckBuilderInteractor.CardsAmountSelected.ToString();
            cardsQuantity.SetDeckSize = deckBuilderInteractor.DeckSize.ToString();
        }
    }
}
