using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardController : IDeckCardController
    {
        [Inject] private readonly ICardShowerPresenter showCardPresenter;
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        public void Clicked(string cardId) => addCard.AddDeckCard(cardId);

        public void HoveredOn(CardShowerDTO showCardDTO) => showCardPresenter.Show(showCardDTO);

        public void HoveredOff() => showCardPresenter.Hide();
    }
}
