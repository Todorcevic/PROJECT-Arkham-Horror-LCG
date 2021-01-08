using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.UI
{
    public abstract class CampaignState : ScriptableObject
    {
        [SerializeField, Required] private string id;
        [SerializeField, Required] private bool isOpen;

        public string Id => id;
        public bool IsOpen => isOpen;

        public abstract void SetState(CampaignButton campaignButton);
    }
}
