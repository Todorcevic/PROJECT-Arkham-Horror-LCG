using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

namespace Arkham.Views
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class BasicCampaignState : CampaignState
    {
        [SerializeField] private Sprite icon;

        public override void ExecuteState(ICampaignView campaignView)
        {
            campaignView.IsOpen = isOpen;
            campaignView.SetImageState(icon);
        }
    }
}
