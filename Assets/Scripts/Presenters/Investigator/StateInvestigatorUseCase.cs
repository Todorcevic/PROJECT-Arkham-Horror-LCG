using Arkham.EventData;
using Arkham.Interactors;
using Zenject;

namespace Arkham.Views
{
    public class StateInvestigatorUseCase : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorInfoInteractor investigatorInteractor;

        /*******************************************************************/
        public void Initialize() => startGameEvent.AddAction(InvestigatorStateResolve);

        /*******************************************************************/
        private void InvestigatorStateResolve()
        {
            foreach (CardInvestigatorView cardInvestigator in cardsManager.InvestigatorList)
            {
                if (investigatorInteractor.ISKilled(cardInvestigator.Id)) cardInvestigator.ChangeToKilledState();
                else if (investigatorInteractor.ISInsane(cardInvestigator.Id)) cardInvestigator.ChangeToInsaneState();
                else if (investigatorInteractor.IsRetired(cardInvestigator.Id)) cardInvestigator.ChangeToRetiredState();
            }
        }
    }
}
