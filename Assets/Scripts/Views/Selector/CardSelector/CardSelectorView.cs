using Arkham.Components;
using Arkham.Views;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public class CardSelectorView : SelectorView, ICardSelectorView
    {
        public void ActiveSelector(bool isActive) => gameObject.SetActive(isActive);
    }
}
