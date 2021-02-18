using Arkham.Controllers;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardComponentRepository
    {
        List<CardController> CardComponentsList { get; }
        Dictionary<string, CardController> AllCardViews { get; }
        List<CardInvestigatorController> InvestigatorListCards { get; }
        List<CardDeckController> DeckListCards { get; }
        CardInvestigatorController GetInvestigator(string id);
        CardDeckController GetDeck(string id);
    }
}
