using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView : IView
    {
        Transform Transform { get; }
        void ActivateGlow(bool activate);
        void SetInvestigator(CardView cardView);
        IEnumerator Reorder();
        void MovePlaceHolder(Transform transform);
        void ChangeImage(Sprite sprite);
    }
}
