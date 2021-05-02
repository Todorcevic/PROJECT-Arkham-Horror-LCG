using Arkham.Model;
using UnityEngine;
using Zenject;

namespace Arkham.Views
{
    [CreateAssetMenu(fileName = "BasicCampaignState", menuName = "BasicCampaignState", order = 1)]
    public class CampaignStateSO : ScriptableObject
    {
        [SerializeField] private Sprite icon;

        public string Id => name;

        /*******************************************************************/
        public void ExecuteState(CampaignView campaignView) => campaignView.ChangeIconState(icon);
    }
}
