using Zenject;
using Arkham.UseCases;

namespace Arkham.Views
{
    public class DeckCardController : ICardController
    {
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly AddCardUseCase addCardEvent;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            addCardEvent.AddCard(cardId);
            cardShower.AddCardAnimation();
        }
    }
}
