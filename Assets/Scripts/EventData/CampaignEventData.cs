using Arkham.Entities;
using Arkham.Repositories;
using System;
using Zenject;

namespace Arkham.EventData
{
    public class CampaignEventData : IChangeCampaign, ICampaignEvent, IChangeScenario, IScenarioEvent
    {
        [Inject] private readonly ICampaignRepository campaignRepository;
        private event Action<string, string> CampaignStateChanged;
        private event Action<string> CurrentScenarioChanged;

        /*******************************************************************/
        void IChangeCampaign.ChangeCampaignState(string campaignId, string state)
        {
            campaignRepository.GetCampaign(campaignId).State = state;
            CampaignStateChanged?.Invoke(campaignId, state);
        }

        void IChangeScenario.SelectingScenario(string scenarioId)
        {
            campaignRepository.CurrentScenario = scenarioId;
            CurrentScenarioChanged?.Invoke(scenarioId);
        }

        void ICampaignEvent.AddAction(Action<string, string> action) => CampaignStateChanged += action;

        void IScenarioEvent.AddAction(Action<string> action) => CurrentScenarioChanged += action;
    }
}
