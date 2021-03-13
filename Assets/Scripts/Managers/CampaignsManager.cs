using Arkham.SettingObjects;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Managers
{
    public class CampaignsManager : MonoBehaviour, ICampaignsManager
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;
        public List<CampaignView> Campaigns => campaigns;

        /*******************************************************************/
        public CampaignState GetState(string campaignState) => states.Find(s => s.Id == campaignState);
        public CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);
    }
}
