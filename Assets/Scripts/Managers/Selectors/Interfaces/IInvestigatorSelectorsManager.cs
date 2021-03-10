using Arkham.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface IInvestigatorSelectorsManager
    {
        Transform SelectorZone { get; }
        List<IInvestigatorSelector> Selectors { get; }
        IInvestigatorSelector GetEmptySelector();
        IInvestigatorSelector GetSelectorById(string cardId);
        void ArrangeSelectors();
    }
}
