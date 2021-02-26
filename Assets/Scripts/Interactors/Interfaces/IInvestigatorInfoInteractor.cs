using Arkham.Models;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface IInvestigatorInfoInteractor
    {
        int GetThisCardAmountInDeck(string investigatorId, string cardId);
        List<string> GetFullDeck(string investigatordId);
    }
}
