using System.Collections.Generic;
using UnityEngine;

namespace Arkham.View
{
    public interface ICardSelectorsManager
    {
        List<CardSelectorView> GetAllFilledSelectors();
        CardSelectorView GetSelectorByCardIdOrEmpty(string cardId);
    }
}
