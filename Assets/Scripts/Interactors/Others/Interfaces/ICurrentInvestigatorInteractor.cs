using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface ICurrentInvestigatorInteractor
    {
        string Id { get; }
        int Xp { get; }
        int DeckSize { get; }
        int AmountCardsSelected { get; }
        List<string> AllowedCards { get; }
        List<string> Deck { get; }
        List<string> MandatoryCards { get; }
        bool SelectionIsFull { get; }
        bool SelectionIsNotFull { get; }
        int GetAmountOfThisCardInDeck(string cardId);
    }
}
