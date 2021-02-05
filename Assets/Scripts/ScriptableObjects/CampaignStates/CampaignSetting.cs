using UnityEngine;
using Sirenix.OdinInspector;

namespace Arkham.Views
{
    //public enum CampaignState
    //{
    //    Completed,
    //    Locked,
    //    Open
    //}

    public abstract class CampaignSetting : ScriptableObject
    {
        [SerializeField, Required] private string id;
        [SerializeField, Required] protected bool isOpen;

        public string Id => id;
        public bool IsOpen => isOpen;

        public abstract void SetState(ICampaignView campaignView);
    }
}
