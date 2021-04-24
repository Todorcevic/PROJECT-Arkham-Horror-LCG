using Sirenix.OdinInspector;
using UnityEngine;

namespace Arkham.View
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class CampaignState : ScriptableObject
    {
        [SerializeField] private Sprite icon;
        [SerializeField, Required] private bool isOpen;

        public string Id => name;
        public bool IsOpen => isOpen;

        /*******************************************************************/
        public void ExecuteState(CampaignView campaignView)
        {
            campaignView.ChangeIconState(icon);
            campaignView.IsOpen = isOpen;
        }
    }
}
