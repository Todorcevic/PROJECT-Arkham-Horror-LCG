using Arkham.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ICardSelectorsManager
    {
        Transform Zone { get; }
        List<ICardSelectorable> Selectors { get; }
        List<ICardSelectorable> GetAllFilledSelectors();
        ICardSelectorable GetSelectorByCardIdOrEmpty(string cardId);
        void CleanAllSelectors();
        void DesactivateSelector(ICardSelectorable selector);
    }
}
