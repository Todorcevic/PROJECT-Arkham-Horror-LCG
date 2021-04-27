using System;

namespace Arkham.Repositories
{
    public interface IInvestigatorChangedEvent
    {
        void Subscribe(Action<string, string> action);
    }
}
