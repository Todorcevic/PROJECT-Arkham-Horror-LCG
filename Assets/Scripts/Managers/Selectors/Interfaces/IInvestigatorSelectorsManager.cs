using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        IInvestigatorSelectorView GetLeadSelector { get; }
        List<IInvestigatorSelectorView> Selectors { get; }
        IInvestigatorSelectorView GetEmptySelector();
        List<IInvestigatorSelectorView> GetAllFilledSelectors();
        IInvestigatorSelectorView GetSelectorById(string cardId);
        void ArrangeSelectors();
    }
}
