using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Arkham.Views
{
    public class CampaignsManager : MonoBehaviour, ICampaignsManager
    {
        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;

        /*******************************************************************/
        public CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        public CampaignState GetState(string campaignState) => states.Find(s => s.Id == campaignState);
    }
}
