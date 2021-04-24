using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardController : IDeckCardController
    {
        [Inject] private readonly IAddCard addCard;

        /*******************************************************************/
        public void Clicked(string cardId) => addCard.AddDeckCard(cardId);
    }
}
