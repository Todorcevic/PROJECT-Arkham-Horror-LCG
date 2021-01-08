using System.Collections.Generic;

namespace Arkham.Model
{
    public class PlayerData
    {
        public string CurrentScenario { get; set; }
        public Dictionary<string, string> CampaignsState { get; set; }
    }
}
