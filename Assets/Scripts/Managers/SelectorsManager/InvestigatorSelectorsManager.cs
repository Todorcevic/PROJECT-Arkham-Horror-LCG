using Arkham.Views;
using System.Collections.Generic;
using System.Linq;

namespace Arkham.Managers
{
    public class InvestigatorSelectorsManager : SelectorsManager, IInvestigatorSelectorsManager
    {
        public List<IInvestigatorSelectorView> InvestigatorSelectors => Selectors.OfType<IInvestigatorSelectorView>().ToList();

        /*******************************************************************/
        public IInvestigatorSelectorView GetSelectorByInvestigatorId(string investigatorId) =>
            InvestigatorSelectors.Find(selector => selector.CardInThisSelector == investigatorId);
        public IInvestigatorSelectorView GetLeadSelector() => InvestigatorSelectors.Find(i => i.IsLead);
    }
}
