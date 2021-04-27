using System;

namespace Arkham.Interactors
{
    public interface ICardRemovedEvent
    {
        void AddAction(Action<string> action);
    }
}
