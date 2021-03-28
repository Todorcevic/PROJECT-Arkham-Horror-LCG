using System;

namespace Arkham.EventData
{
    public interface IUnlockCardEvent
    {
        void AddAction(Action action);
    }
}
