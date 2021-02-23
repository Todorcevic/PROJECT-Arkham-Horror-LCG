using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public class LeadActivator : MonoBehaviour
    {
        [SerializeField, Required, ChildGameObjectsOnly] private Image leaderIcon;

        /*******************************************************************/
        public bool IsLead => leaderIcon.enabled;
        public void ActivateLeader(bool activate) => leaderIcon.enabled = activate;
    }
}
