using System;

namespace Arkham.EventData
{
    public interface IChangeInvestigatorEvent
    {
        void AddAction(Action<string, string> action);
    }
}
