using Arkham.Interactors;
using System;
using System.ComponentModel;
using Zenject;

namespace Arkham.EventData
{
    public class AddCardEventData : IAddCard, IAddCardEvent
    {
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        private event Action<string> DeckCardAdded;

        /*******************************************************************/
        void IAddCard.AddDeckCard(string deckCardId)
        {
            currentInvestigator.Deck.Add(deckCardId);
            DeckCardAdded?.Invoke(deckCardId);
        }

        void IAddCardEvent.AddAction(Action<string> action) => DeckCardAdded += action;
    }
}
