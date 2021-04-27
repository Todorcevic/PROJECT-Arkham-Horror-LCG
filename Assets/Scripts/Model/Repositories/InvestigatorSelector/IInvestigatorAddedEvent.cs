using System;

namespace Arkham.Repositories
{
    interface IInvestigatorAddedEvent
    {
        void Subscribe(Action<string> action);
    }
}
