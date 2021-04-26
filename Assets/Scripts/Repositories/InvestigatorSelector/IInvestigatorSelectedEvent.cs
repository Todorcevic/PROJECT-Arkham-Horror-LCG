using System;

namespace Arkham.Repositories
{
    public interface IInvestigatorSelectedEvent
    {
        void Subscribe(Action<string> action);
    }
}
