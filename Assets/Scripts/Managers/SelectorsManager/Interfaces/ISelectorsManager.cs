using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ISelectorsManager
    {
        Transform PlaceHolder { get; }
        List<T> Selectors<T>() where T : ISelectorView;
        T GetEmptySelector<T>() where T : ISelectorView;
        List<T> GetAllFilledSelectors<T>() where T : ISelectorView;
        T GetSelectorById<T>(string cardId) where T : ISelectorView;
    }
}
