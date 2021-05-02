using Arkham.Model;
using Zenject;
using Arkham.Adapter;

namespace Arkham.Views
{
    public class InvestigatorStatePresenter : IInitializable
    {
        [Inject] private readonly StartGameEventDomain startGameEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly InvestigatorRepository investigatorManager;

        /*******************************************************************/
        public void Initialize() => startGameEvent.Subscribe((_) => InvestigatorStateResolve());

        /*******************************************************************/
        private void InvestigatorStateResolve()
        {
            foreach (InvestigatorCardView cardInvestigator in cardsManager.InvestigatorList)
            {
                if (investigatorManager.Get(cardInvestigator.Id).ISKilled)
                    cardInvestigator.ChangeToKilledState();
                else if (investigatorManager.Get(cardInvestigator.Id).ISInsane)
                    cardInvestigator.ChangeToInsaneState();
                else if (investigatorManager.Get(cardInvestigator.Id).IsRetired)
                    cardInvestigator.ChangeToRetiredState();
            }
        }
    }
}
