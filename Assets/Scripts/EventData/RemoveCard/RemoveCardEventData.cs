using Arkham.Interactors;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class RemoveCardEventData : IRemoveCard, IRemoveCardEvent
    {
        [Inject] private readonly ICurrentInvestigatorInteractor currentInvestigator;
        private event Action<string> DeckCardRemoved;

        /*******************************************************************/
        void IRemoveCard.RemoveDeckCard(string deckCardId)
        {
            currentInvestigator.Deck.Remove(deckCardId);
            DeckCardRemoved?.Invoke(deckCardId);
        }

        void IRemoveCardEvent.AddAction(Action<string> action) => DeckCardRemoved += action;
    }
}
