using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class LeadActivator : MonoBehaviour
    {
        [SerializeField, Required] private Image leaderIcon;

        /*******************************************************************/
        public bool IsLeader => leaderIcon.enabled;
        public void ActivateLeaderIcon(bool activate) => leaderIcon.enabled = activate;
    }
}
