using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class DeckCardController : IDeckCardController
    {
        [Inject] private readonly IInvestigatorSelected investigatorSelected;

        /*******************************************************************/
        public void Clicked(string cardId) => investigatorSelected.AddCard(cardId);
    }
}
