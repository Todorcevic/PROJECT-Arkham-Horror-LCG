using System.Collections.Generic;
using UnityEngine;

namespace Arkham.View
{
    public interface IInvestigatorSelectorsManager
    {
        InvestigatorSelectorView GetLeadSelector { get; }
        InvestigatorSelectorView GetEmptySelector();
        InvestigatorSelectorView GetSelectorById(string cardId);
        void EmptyAllSelectors();
        void ArrangeAllSelectors();
        void RebuildPlaceHolders();
    }
}
