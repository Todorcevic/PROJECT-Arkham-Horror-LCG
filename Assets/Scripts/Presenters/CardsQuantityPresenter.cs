using Zenject;
using TMPro;
using Arkham.Interactors;

namespace Arkham.Presenters
{
    public class CardsQuantityPresenter : ICardsQuantityPresenter
    {
        [Inject] private readonly IDeckBuilderInteractor deckBuilderInteractor;
        [Inject] private readonly IInvestigatorSelectorInteractor investigatorSelectorInteractor;
        [Inject(Id = "CardsAmountSelected")] private readonly TextMeshProUGUI cardsAmountText;
        [Inject(Id = "DeckSize")] private readonly TextMeshProUGUI deckSizeText;

        /*******************************************************************/
        public void Init()
        {
            deckBuilderInteractor.DeckCardAdded += ChangeText;
            deckBuilderInteractor.DeckCardRemoved += ChangeText;
            investigatorSelectorInteractor.InvestigatorSelectedChanged += ChangeText;
            ChangeText(null);
        }

        private void ChangeText(string _)
        {
            cardsAmountText.text = deckBuilderInteractor.CardsAmountSelected.ToString();
            deckSizeText.text = deckBuilderInteractor.DeckSize.ToString();
        }
    }
}
