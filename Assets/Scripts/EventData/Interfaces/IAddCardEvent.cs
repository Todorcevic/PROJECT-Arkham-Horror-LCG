using System;

namespace Arkham.EventData
{
    public interface IAddCardEvent
    {
        event Action<string> DeckCardAdded;
    }
}
