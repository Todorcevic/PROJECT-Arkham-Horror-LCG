using UnityEngine;
using Sirenix.OdinInspector;
using Arkham.Controllers;
using Arkham.Views;

namespace Arkham.ScriptableObjects
{
    public abstract class CampaignState : ScriptableObject, ICampaignState
    {
        [SerializeField, Required] protected bool isOpen;
        public string Id => name;
        public bool IsOpen => isOpen;

        /*******************************************************************/
        public abstract void ExecuteState(ICampaignView campaignView);
    }
}
