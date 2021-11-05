using Zenject;

namespace Arkham.Application
{
    public class DeckCardController : CardController
    {
        [Inject] private readonly InvestigatorSelectorsManager investigatorSelectorManager;
        [Inject] private readonly AddCardUseCase addCardUseCase;

        /*******************************************************************/
        protected override void Clicked() =>
            addCardUseCase.AddCard(cardView.Id, investigatorSelectorManager.CurrentInvestigatorId);

    }
}
