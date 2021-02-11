using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Repositories
{
    public interface ICardViewsRepository
    {
        List<CardView> CardViewsList { get; }
        Dictionary<string, CardView> AllCardViews { get; }
    }
}
