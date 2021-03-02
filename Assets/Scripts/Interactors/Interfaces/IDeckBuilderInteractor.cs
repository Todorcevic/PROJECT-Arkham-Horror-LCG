using Arkham.Entities;
using System;

namespace Arkham.Interactors
{
    public interface IDeckBuilderInteractor
    {
        event Action<string> DeckCardAdded;
        event Action<string> DeckCardRemoved;
        int? DeckSize { get; }
        int? CardsAmountSelected { get; }
        bool SelectionIsFull { get; }
        bool SelectionIsNotFull { get; }
        InvestigatorInfo GetInvestigatorById(string investigatorId);
        void AddDeckCard(string deckCardId);
        void RemoveDeckCard(string deckCardId);
        int AmountSelectedOfThisCard(string idCard);
    }
}
