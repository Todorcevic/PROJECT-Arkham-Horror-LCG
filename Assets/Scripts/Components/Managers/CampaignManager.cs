using Arkham.Repositories;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Zenject;

namespace Arkham.Managers
{
    public class CampaignManager : MonoBehaviour, ICampaignManager
    {
        [Inject] private readonly Repository allData;

        [Title("STATES")]
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField] private List<CampaignState> states;

        private void Start()
        {
            foreach (ICampaignView campaign in campaigns)
                SetState(campaign);
        }

        public void SetState(ICampaignView campaign) => GetState(campaign.Id).ExecuteState(campaign);

        private CampaignState GetState(string campaignId) =>
            states.Find(s => s.Id == allData.AllCampaigns[campaignId].State);
    }
}
