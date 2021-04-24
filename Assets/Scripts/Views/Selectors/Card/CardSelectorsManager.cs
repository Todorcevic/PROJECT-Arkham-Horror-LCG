using System.Collections.Generic;
using Zenject;

namespace Arkham.Views
{
    public class CardSelectorsManager : ICardSelectorsManager
    {
        [Inject] private readonly List<CardSelectorView> selectors;

        /*******************************************************************/
        public List<CardSelectorView> GetAllFilledSelectors() =>
            selectors.FindAll(selector => selector.Id != null);

        public CardSelectorView GetSelectorByCardIdOrEmpty(string cardId) =>
            selectors.Find(selector => selector.Id == cardId) ?? GetEmptySelector();

        private CardSelectorView GetEmptySelector() =>
            selectors.Find(selector => selector.Id == null);
    }
}
