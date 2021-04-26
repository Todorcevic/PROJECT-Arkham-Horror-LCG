using System;

namespace Arkham.Repositories
{
    public interface IInvestigatorRemovedEvent
    {
        void Subscribe(Action<string> action);
    }
}
