using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    public abstract class CampaignState : ScriptableObject, ICampaignState
    {
        [SerializeField, Required] private string id;
        [SerializeField, Required] protected bool isOpen;

        public string Id => id;
        public bool IsOpen => isOpen;

        public abstract void ExecuteState(ICampaignView campaignView);
    }
}
