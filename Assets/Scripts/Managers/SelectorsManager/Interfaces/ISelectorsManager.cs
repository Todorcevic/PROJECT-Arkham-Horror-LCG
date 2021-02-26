using Arkham.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public interface ISelectorsManager
    {
        Transform PlaceHolder { get; }
        ISelectorView GetVoidSelector();
    }
}
