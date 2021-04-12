using System;

namespace Arkham.EventData
{
    public interface ISelectInvestigatorEvent
    {
        void AddAction(Action<string> action);
    }
}
