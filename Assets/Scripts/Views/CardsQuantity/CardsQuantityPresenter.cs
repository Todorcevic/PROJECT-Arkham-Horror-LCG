using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class CardsQuantityPresenter
    {
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardsQuantityView cardsQuantityView;

        private string AmountCards => selector.InvestigatorSelected?.AmountCardsSelected.ToString();
        private string DeckSize => selector.InvestigatorSelected?.DeckBuilding.DeckSize.ToString();

        /*******************************************************************/
        public void Refresh()
        {
            cardsQuantityView.SetCardsAmount(AmountCards);
            cardsQuantityView.SetDeckSize(DeckSize);
        }
    }
}
