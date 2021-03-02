using Arkham.Entities;
using System;
using System.Collections;

namespace Arkham.Interactors
{
    public interface ICampaignInteractor
    {
        event Action<string> CampaignStateChanged;
        string CurrentScenario { get; set; }
        IEnumerable CampaignsList { get; }
        string GetState(string campaignId);
        string GetScenario(string campaignId);
        void ChangeCampaignState(string campaignId, string state, bool isOpen);
    }
}
