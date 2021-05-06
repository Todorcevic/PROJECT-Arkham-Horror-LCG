using Zenject;
using Arkham.Application;

namespace Arkham.Application
{
    public class DeckCardController : ICardController
    {
        [Inject] private readonly CardShowerPresenter cardShower;
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardEvent;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            addCardEvent.AddCard(cardId, investigatorSelectorManager.CurrentInvestigatorId);
            cardShower.AddCardAnimation();
        }
    }
}
