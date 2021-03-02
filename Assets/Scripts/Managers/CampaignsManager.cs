using Arkham.SettingObjects;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Arkham.Managers
{
    public class CampaignsManager : MonoBehaviour, ICampaignsManager
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;
        public List<ICampaignConfigurable> Campaigns => campaigns.OfType<ICampaignConfigurable>().ToList();

        /*******************************************************************/
        public ICampaignState GetState(string campaignState) => states.Find(s => s.Id == campaignState);
        public ICampaignConfigurable GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        public void ExecuteStateWithCampaign(string state, string campaignId)
        {
            ICampaignConfigurable campaignView = GetCampaign(campaignId);
            GetState(state).ExecuteState(campaignView);
        }
    }
}
