using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class CardsQuantityPresenter : IInitializable
    {
        [Inject] private readonly AddCardEventDomain addCardEvent;
        [Inject] private readonly RemoveCardEventDomain removeCardEvent;
        [Inject] private readonly SelectInvestigatorEventDomain investigatorSelectEvent;
        [Inject] private readonly Selector selector;
        [Inject] private readonly CardsQuantityView cardsQuantityView;

        private string AmountCards => selector.InvestigatorSelected?.AmountCardsSelected.ToString();
        private string DeckSize => selector.InvestigatorSelected?.DeckBuilder.DeckSize.ToString();

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            addCardEvent.Subscribe((_) => UpdateData());
            removeCardEvent.Subscribe((_) => UpdateData());
            investigatorSelectEvent.Subscribe((_) => UpdateData());
        }

        /*******************************************************************/
        private void UpdateData()
        {
            cardsQuantityView.SetCardsAmount(AmountCards);
            cardsQuantityView.SetDeckSize(DeckSize);
        }
    }
}
