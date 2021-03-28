using System;

namespace Arkham.EventData
{
    interface IAddInvestigatorEvent
    {
        void AddAction(Action<string> action);
    }
}
