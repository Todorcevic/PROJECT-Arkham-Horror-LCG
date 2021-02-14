using Arkham.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface IInvestigatorSelectorView : IView, IInteractable
    {
        string InvestigatorId { get; set; }
        bool IsEmpty { get; }
        Transform Transform { get; }
        void ActivateGlow(bool activate);
        IEnumerator Reorder();
        void MovePlaceHolder(Transform transform);
        void Activate(bool isEnable);
        void ChangeImage(Sprite sprite);
    }
}
