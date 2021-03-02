using Zenject;
using Arkham.Interactors;
using Arkham.Views;

namespace Arkham.Presenters
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject] private readonly ICardsQuantityView cardsQuantity;

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
