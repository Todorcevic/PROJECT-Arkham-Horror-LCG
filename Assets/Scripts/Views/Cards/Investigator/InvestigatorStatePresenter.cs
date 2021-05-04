using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorStatePresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorRepository investigatorRepository;

        /*******************************************************************/
        public void InvestigatorStateResolve()
        {
            foreach (InvestigatorCardView cardInvestigator in cardsManager.InvestigatorList)
            {
                if (investigatorRepository.Get(cardInvestigator.Id).State == InvestigatorState.Killed)
                    cardInvestigator.ChangeToKilledState();
                else if (investigatorRepository.Get(cardInvestigator.Id).State == InvestigatorState.Insane)
                    cardInvestigator.ChangeToInsaneState();
                else if (investigatorRepository.Get(cardInvestigator.Id).State == InvestigatorState.Retired)
                    cardInvestigator.ChangeToRetiredState();
            }
        }
    }
}
