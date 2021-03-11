using Arkham.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        List<IInvestigatorSelector> Selectors { get; }
        IInvestigatorSelector GetLeadSelector { get; }
        IInvestigatorSelector GetEmptySelector();
        IInvestigatorSelector GetSelectorById(string cardId);
        void ArrangeSelectorsAndSetThisLead(string leadInvestigatorId);
    }
}
