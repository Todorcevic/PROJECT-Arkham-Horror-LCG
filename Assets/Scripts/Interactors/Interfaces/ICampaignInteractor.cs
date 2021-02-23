using Arkham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Interactors
{
    public interface ICampaignInteractor
    {
        event Action<CampaignInfo> CampaignStateChanged;
        List<CampaignInfo> CampaignsList { get; }
        void InitializeCampaigns();
        void AddScenarioToPlay(string scenario);
        CampaignInfo GetCampaign(string id);
        void ChangeCampaignState(CampaignInfo campaignInfo);
    }
}
