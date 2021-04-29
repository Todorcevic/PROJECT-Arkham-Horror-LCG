using System.Collections.Generic;

namespace Arkham.Views
{
    public interface ICardSelectorsManager
    {
        List<CardSelectorView> GetAllFilledSelectors();
        CardSelectorView GetSelectorByCardIdOrEmpty(string cardId);
    }
}
