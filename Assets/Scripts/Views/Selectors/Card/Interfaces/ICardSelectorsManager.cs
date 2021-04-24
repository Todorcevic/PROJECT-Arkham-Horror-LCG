using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardSelectorsManager
    {
        List<CardSelectorView> GetAllFilledSelectors();
        CardSelectorView GetSelectorByCardIdOrEmpty(string cardId);
    }
}
