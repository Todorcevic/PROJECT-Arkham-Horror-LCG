using UnityEngine;

namespace Arkham.UI
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class BasicCampaignState : CampaignState
    {
        [SerializeField] private Sprite icon;

        public override void SetState(CampaignButton campaignButton)
        {
            campaignButton.StateCanvas.alpha = icon == null ? 0 : 1;
            campaignButton.StateImage.sprite = icon;
        }
    }
}
