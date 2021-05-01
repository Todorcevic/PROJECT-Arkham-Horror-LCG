using Arkham.Model;
using System.Collections.Generic;

namespace Arkham.Services
{
    public class CampaignStateFactory : ICampaignStateFactory
    {
        public List<CampaignState> Create()
        {
            return new List<CampaignState>()
            {
                new CampaignState(){ Id = "Open", IsOpen = true},
                new CampaignState(){ Id = "Lock", IsOpen = false},
                new CampaignState(){ Id = "Complete", IsOpen = false}
            };
        }
    }
}
