using UnityEngine;

namespace Arkham.Presenters
{
    public interface IInvestigatorSelectorable : ISelectorable
    {
        bool IsLeader { get; }
        void MoveTo(Transform transform);
        void Arrange(Transform transform);
        void ActivateLeaderIcon(bool activate);
    }
}
