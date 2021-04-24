using Arkham.Entities;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface IInvestigatorInfoInteractor
    {
        int GetAmountOfThisCardInDeck(string investigatorId, string cardId);
        List<string> GetFullDeck(string investigatordId);
        int AmountSelectedOfThisCard(string cardId);
        DeckBuildingRules GetDeckBuilding(string investigatorId);
        bool IsRetired(string investigatorId);
        bool ISKilled(string investigatorId);
        bool ISInsane(string investigatorId);
        bool IsEliminated(string investigatorId);
    }
}
