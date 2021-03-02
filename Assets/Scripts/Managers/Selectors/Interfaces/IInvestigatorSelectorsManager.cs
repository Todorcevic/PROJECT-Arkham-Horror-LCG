using Arkham.Presenters;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        IInvestigatorSelectorable GetLeadSelector { get; }
        List<IInvestigatorSelectorable> Selectors { get; }
        IInvestigatorSelectorable GetEmptySelector();
        IInvestigatorSelectorable GetSelectorById(string cardId);
        void SetLeadAndArrangeSelectors(string leadInvestigatorId);
    }
}
