using System;

namespace Arkham.Interactors
{
    public interface ICardAddedEvent
    {
        void AddAction(Action<string> action);
    }
}
