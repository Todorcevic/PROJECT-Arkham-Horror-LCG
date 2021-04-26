using Arkham.EventData;
using Arkham.Interactors;
using Arkham.Repositories;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardStatePresenter : IInitializable
    {
        [Inject] private readonly IStartGameEvent startGameEvent;
        [Inject] private readonly ICardsManager cardsManager;
        [Inject] private readonly IInvestigatorInfo investigatorRepository;

        /*******************************************************************/
        public void Initialize() => startGameEvent.AddAction(InvestigatorStateResolve);

        /*******************************************************************/
        private void InvestigatorStateResolve()
        {
            foreach (InvestigatorCardView cardInvestigator in cardsManager.InvestigatorList)
            {
                if (investigatorRepository.Get(cardInvestigator.Id).ISKilled)
                    cardInvestigator.ChangeToKilledState();
                else if (investigatorRepository.Get(cardInvestigator.Id).ISInsane)
                    cardInvestigator.ChangeToInsaneState();
                else if (investigatorRepository.Get(cardInvestigator.Id).IsRetired)
                    cardInvestigator.ChangeToRetiredState();
            }
        }
    }
}
