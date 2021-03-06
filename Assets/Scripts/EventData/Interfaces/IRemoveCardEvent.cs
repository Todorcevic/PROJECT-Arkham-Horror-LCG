using System;

namespace Arkham.EventData
{
    public interface IRemoveCardEvent
    {
        event Action<string> DeckCardRemoved;
    }
}
