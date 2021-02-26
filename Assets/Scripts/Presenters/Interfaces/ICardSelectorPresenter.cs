using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Presenters
{
    public interface ICardSelectorPresenter
    {
        List<ICardSelectorView> Selectors { get; }
        void Init();
    }
}
