using System;

namespace Arkham.EventData
{
    public interface ISelectInvestigatorEvent
    {
        void AddSelectedAction(Action<string> action);
    }
}
