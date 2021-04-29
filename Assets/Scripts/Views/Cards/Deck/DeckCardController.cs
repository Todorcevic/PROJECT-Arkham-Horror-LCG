using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardController : IDeckCardController
    {
        [Inject] private readonly AddCardEventDomain investigatorSelected;

        /*******************************************************************/
        public void Clicked(string cardId) => investigatorSelected.AddCard(cardId);
    }
}
