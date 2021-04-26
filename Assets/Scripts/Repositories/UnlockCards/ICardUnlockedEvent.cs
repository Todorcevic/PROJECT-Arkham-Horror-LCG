using System;

namespace Arkham.Repositories
{
    public interface ICardUnlockedEvent
    {
        void Subscribe(Action action);
    }
}
