using Arkham.Views;
using UnityEngine;

namespace Arkham.SettingObjects
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class BasicCampaignState : CampaignState
    {
        [SerializeField] private Sprite icon;

        /*******************************************************************/
        public override void ExecuteState(CampaignView campaignView)
        {
            campaignView.IsOpen = isOpen;
            campaignView.ChangeIconState(icon);
        }
    }
}
