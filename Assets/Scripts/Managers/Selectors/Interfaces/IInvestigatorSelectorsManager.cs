using Arkham.Presenters;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        IInvestigatorSelector GetLeadSelector { get; }
        List<IInvestigatorSelector> Selectors { get; }
        IInvestigatorSelector GetEmptySelector();
        IInvestigatorSelector GetSelectorById(string cardId);
        void SetLeadAndArrangeSelectors(string leadInvestigatorId);
    }
}
