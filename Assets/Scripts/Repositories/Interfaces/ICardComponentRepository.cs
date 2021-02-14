using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardComponentRepository
    {
        List<ICardView> CardComponentsList { get; }
        Dictionary<string, ICardView> AllCardViews { get; }
        List<IInvestigatorView> InvestigatorListCards { get; }
        List<IDeckView> DeckListCards { get; }
    }
}
