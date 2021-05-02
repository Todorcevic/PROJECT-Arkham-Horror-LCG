using Arkham.Model;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorStatePresenter
    {
        [Inject] private readonly CardsManager cardsManager;
        [Inject] private readonly InvestigatorRepository investigatorManager;

        /*******************************************************************/
        public void InvestigatorStateResolve()
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
