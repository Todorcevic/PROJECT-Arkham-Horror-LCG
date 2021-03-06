using UnityEngine;

namespace Arkham.Presenters
{
    public interface IInvestigatorSelector : ISelector
    {
        bool IsLeader { get; }
        void MoveTo(Transform transform);
        void Arrange(Transform transform);
        void ActivateLeaderIcon(bool activate);
    }
}
