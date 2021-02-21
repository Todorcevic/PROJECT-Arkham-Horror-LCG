using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Presenters
{
    public interface ICardPresenter
    {
        void Init();
        void RefreshCardVisibility(string cardId);
        void RefreshAllCardsVisibility();
    }
}
