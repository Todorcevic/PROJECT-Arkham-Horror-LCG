using System;
using UnityEngine;

namespace Arkham.Presenters
{
    public interface IInvestigatorSelector : ISelector
    {
        bool IsLeader { get; }
        Transform PlaceHolder { get; }
        void MoveImageTo(Transform transform);
        void SetTransform(Transform transform);
        void ArrangeTo();
        void SwapPlaceHolder(Transform selectorDragging);
        void ActivateLeaderIcon(bool activate);
    }
}
