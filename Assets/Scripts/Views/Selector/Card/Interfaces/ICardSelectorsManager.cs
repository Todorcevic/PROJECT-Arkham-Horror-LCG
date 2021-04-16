using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICardSelectorsManager
    {
        Transform PlaceHolderZone { get; }
        Transform SelectorsZone { get; }
        List<CardSelectorView> Selectors { get; }
        List<CardSelectorView> GetAllFilledSelectors();
        CardSelectorView GetSelectorByCardIdOrEmpty(string cardId);
    }
}
