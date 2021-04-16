using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorsManager
    {
        Transform PlaceHoldersZone { get; }
        List<InvestigatorSelectorView> Selectors { get; }
        InvestigatorSelectorView GetLeadSelector { get; }
        InvestigatorSelectorView GetEmptySelector();
        InvestigatorSelectorView GetSelectorById(string cardId);
        void RebuildPlaceHolders();
    }
}
