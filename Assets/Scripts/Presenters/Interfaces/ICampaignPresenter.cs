using Arkham.Models;
using Arkham.Views;
using System.Collections.Generic;

namespace Arkham.Presenters
{
    public interface ICampaignPresenter
    {
        void Init();
        List<ICampaignView> Campaigns { get; }
        void SetCampaign(CampaignInfo campaignInfo);
    }
}
