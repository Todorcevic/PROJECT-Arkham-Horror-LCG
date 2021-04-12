using System;

namespace Arkham.EventData
{
    public interface IRemoveInvestigatorEvent
    {
        void AddAction(Action<string> action);
    }
}
