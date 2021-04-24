using Arkham.EventData;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorCardController : IInvestigatorCardController
    {
        [Inject] private readonly IAddInvestigator addInvestigator;
        [Inject] private readonly ISelectInvestigator selectInvestigator;

        /*******************************************************************/
        public void Clicked(string cardId)
        {
            addInvestigator.AddInvestigator(cardId);
            selectInvestigator.Selecting(cardId);
        }
    }
}
