using Arkham.Models;
using System;
using System.Collections.Generic;

namespace Arkham.Interactors
{
    public interface ICampaignInteractor
    {
        event Action<CampaignInfo> CampaignStateChanged;
        string CurrentScenario { get; }
        List<CampaignInfo> CampaignsList { get; }
        void InitializeCampaigns();
        void AddScenarioToPlay(string scenario);
        CampaignInfo GetCampaign(string id);
        void ChangeCampaignState(CampaignInfo campaignInfo);
    }
}
