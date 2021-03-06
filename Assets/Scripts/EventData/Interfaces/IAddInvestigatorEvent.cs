using System;

namespace Arkham.EventData
{
    interface IAddInvestigatorEvent
    {
        event Action<string> InvestigatorAdded;
    }
}
