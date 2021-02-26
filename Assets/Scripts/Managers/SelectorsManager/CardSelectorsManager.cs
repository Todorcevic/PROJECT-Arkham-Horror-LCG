using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class CardSelectorsManager : SelectorsManager, ICardSelectorsManager
    {
        public List<ICardSelectorView> CardSelectors => Selectors.OfType<ICardSelectorView>().ToList();

        /*******************************************************************/
        public ICardSelectorView GetSelectorByCardId(string cardId) =>
            CardSelectors.Find(selector => selector.CardInThisSelector == cardId);
    }
}
