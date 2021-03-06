using System;

namespace Arkham.EventData
{
    public interface IRemoveInvestigatorEvent
    {
        event Action<string> InvestigatorRemoved;
    }
}
