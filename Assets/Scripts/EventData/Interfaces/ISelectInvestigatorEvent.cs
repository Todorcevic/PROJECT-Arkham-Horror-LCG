using System;

namespace Arkham.EventData
{
    public interface ISelectInvestigatorEvent
    {
        event Action<string> InvestigatorSelectedChanged;
    }
}
