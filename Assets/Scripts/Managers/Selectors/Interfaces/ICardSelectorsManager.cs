using Arkham.Presenters;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ICardSelectorsManager
    {
        Transform Zone { get; }
        List<ICardSelector> Selectors { get; }
        List<ICardSelector> GetAllFilledSelectors();
        ICardSelector GetSelectorByCardIdOrEmpty(string cardId);
        void CleanAllSelectors();
        void DesactivateSelector(ICardSelector selector);
    }
}
