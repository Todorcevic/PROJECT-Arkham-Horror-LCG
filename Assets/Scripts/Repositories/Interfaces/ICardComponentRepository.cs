using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardComponentRepository
    {
        List<ICardComponent> CardComponentsList { get; }
        Dictionary<string, ICardComponent> AllCardComponents { get; }
        List<IInvestigatorComponent> InvestigatorListCards { get; }
        List<IDeckComponent> DeckListCards { get; }
    }
}
