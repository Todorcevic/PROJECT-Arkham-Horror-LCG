using Arkham.Models;
using System;

namespace Arkham.Interactors
{
    public interface IDeckBuilderInteractor
    {
        event Action<string> DeckCardAdded;
        event Action<string> DeckCardRemoved;
        InvestigatorInfo GetInvestigatorById(string investigatorId);
        void AddDeckCard(string deckCardId);
        void RemoveDeckCard(string deckCardId);
    }
}
