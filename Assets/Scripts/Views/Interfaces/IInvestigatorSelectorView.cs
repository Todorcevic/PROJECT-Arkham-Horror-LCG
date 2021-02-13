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
        string InvestigatorId { get; }
        bool IsEmpty { get; }
        Transform Transform { get; }
        void ActivateGlow(bool activate);
        void SetInvestigator(ICardView cardView);
        IEnumerator Reorder();
        void MovePlaceHolder(Transform transform);
        void ChangeImage(Sprite sprite);
    }
}
