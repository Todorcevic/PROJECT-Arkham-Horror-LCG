using UnityEngine;

namespace Arkham.Application.MainMenu
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class CampaignStateSO : ScriptableObject
    {
        [SerializeField] private bool isClickable;
        [SerializeField] private Sprite icon;

        public string Id => name;
        public bool Isclickable => isClickable;

        /*******************************************************************/
        public void ExecuteState(CampaignView campaignView) => campaignView.ChangeIconState(icon);
    }
}
