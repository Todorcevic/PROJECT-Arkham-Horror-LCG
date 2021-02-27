using Arkham.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ICardSelectorsManager
    {
        Transform Zone { get; }
        Transform PlaceHolder { get; }
        List<ICardSelectorView> Selectors { get; }
        List<ICardSelectorView> GetAllFilledSelectors();
        ICardSelectorView GetSelectorByCardIdOrEmpty(string cardId);
    }
}
