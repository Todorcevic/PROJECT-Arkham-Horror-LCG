using Arkham.EventData;
using Arkham.Interactors;
using Arkham.SettingObjects;
using Arkham.Views;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Arkham.Managers
{
    public class CampaignsManager : MonoBehaviour
    {
        [Inject] private readonly ICampaignInteractor campaignInteractor;
        [Inject] private readonly ICampaignEvent changeCampaignEvent;
        [Inject] private readonly IStartGameEvent startGameEvent;

        [Title("RESOURCES")]
        [SerializeField, SceneObjectsOnly] private List<CampaignView> campaigns;
        [SerializeField, AssetsOnly] private List<CampaignState> states;

        /*******************************************************************/
        private void Start()
        {
            startGameEvent.AddAction(InitializeCampaigns);
            changeCampaignEvent.AddAction(ExecuteStateWithCampaign);
        }

        private CampaignState GetState(string campaignState) => states.Find(s => s.Id == campaignState);
        private CampaignView GetCampaign(string campaignId) => campaigns.Find(c => c.Id == campaignId);

        private void InitializeCampaigns()
        {
            foreach (string campaignId in campaignInteractor.CampaignsList)
            {
                string state = campaignInteractor.GetState(campaignId);
                ExecuteStateWithCampaign(campaignId, state);
            }
        }

        private void ExecuteStateWithCampaign(string campaignId, string state)
        {
            CampaignView campaignView = GetCampaign(campaignId);
            GetState(state).ExecuteState(campaignView);
        }
    }
}
