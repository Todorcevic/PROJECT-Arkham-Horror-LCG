using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardComponentRepository
    {
        List<ICardView> CardComponentsList { get; }
        Dictionary<string, ICardView> AllCardComponents { get; }
        List<IInvestigatorView> InvestigatorListCards { get; }
        List<IDeckView> DeckListCards { get; }
    }
}
