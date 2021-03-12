using System;

namespace Arkham.EventData
{
    public interface IChangeInvestigatorEvent
    {
        event Action<string, string> InvestigatorChanged;
    }
}
