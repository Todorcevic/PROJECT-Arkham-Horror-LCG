using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Managers
{
    public interface ICardSelectorsManager : ISelectorsManager
    {
        List<ICardSelectorView> CardSelectors { get; }
        ICardSelectorView GetSelectorByCardId(string cardId);
    }
}
