using Arkham.Interactors;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class AddCardEventData : IAddCard, IAddCardEvent
    {
        [Inject] private readonly ICurrentInvestigator currentInvestigator;
        public event Action<string> DeckCardAdded;

        /*******************************************************************/
        public void AddDeckCard(string deckCardId)
        {
            currentInvestigator.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }
    }
}
