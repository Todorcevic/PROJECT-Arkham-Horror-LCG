using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class DeckCardController : ICardController
    {
        [Inject] private readonly AddCardUseCase addCardEvent;

        /*******************************************************************/
        public void Clicked(string cardId) => addCardEvent.AddCard(cardId);
    }
}
