using Arkham.Interactors;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class RemoveCardEventData : IRemoveCard, IRemoveCardEvent
    {
        [Inject] private readonly ICurrentInvestigator currentInvestigator;
        public event Action<string> DeckCardRemoved;

        /*******************************************************************/
        public void RemoveDeckCard(string deckCardId)
        {
            currentInvestigator.Deck.Remove(deckCardId);
            DeckCardRemoved?.Invoke(deckCardId);
        }
    }
}
