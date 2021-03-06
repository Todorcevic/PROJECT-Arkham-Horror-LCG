using Arkham.Entities;
using Arkham.Investigators;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface IInvestigatorInfoInteractor
    {
        int GetAmountOfThisCardInDeck(string investigatorId, string cardId);
        List<string> GetFullDeck(string investigatordId);
        int AmountSelectedOfThisCard(string cardId);
        DeckBuildingRules GetDeckBuilding(string investigatorId);
    }
}
