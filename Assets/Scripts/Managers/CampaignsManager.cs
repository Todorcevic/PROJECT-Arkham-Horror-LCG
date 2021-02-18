using Arkham.Controllers;
using Arkham.ScriptableObjects;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Managers
{
    public class CampaignsManager : MonoBehaviour, ICampaignsManager
    {
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;
        public List<CampaignView> Campaigns => campaigns;

        /*******************************************************************/
        public ICampaignState GetCampaignState(string campaignState) => states.Find(s => s.Id == campaignState);
        public ICampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);
    }
}
