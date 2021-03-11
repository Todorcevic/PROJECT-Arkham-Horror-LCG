using Arkham.Views;
using UnityEngine;

namespace Arkham.Presenters
{
    public interface IInvestigatorSelector : ISelector
    {
        bool IsLeader { get; }
        void MoveImageTo(Transform transform);
        void ArrangeTo(Transform transform);
        void ActivateLeaderIcon(bool activate);
    }
}
