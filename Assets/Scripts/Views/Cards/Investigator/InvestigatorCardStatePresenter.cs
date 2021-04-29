using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardStatePresenter : IInitializable
    {
        [Inject] private readonly StartGameEventDomain startGameEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly InvestigatorInfoRepository investigatorInfo;

        /*******************************************************************/
        public void Initialize() => startGameEvent.GameStarted += (_) => InvestigatorStateResolve();

        /*******************************************************************/
        private void InvestigatorStateResolve()
        {
            foreach (InvestigatorCardView cardInvestigator in cardsManager.InvestigatorList)
            {
                if (investigatorInfo.Get(cardInvestigator.Id).ISKilled)
                    cardInvestigator.ChangeToKilledState();
                else if (investigatorInfo.Get(cardInvestigator.Id).ISInsane)
                    cardInvestigator.ChangeToInsaneState();
                else if (investigatorInfo.Get(cardInvestigator.Id).IsRetired)
                    cardInvestigator.ChangeToRetiredState();
            }
        }
    }
}
