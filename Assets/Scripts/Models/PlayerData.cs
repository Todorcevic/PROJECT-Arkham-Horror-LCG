using System.Collections.Generic;
using Arkham.Investigators;

namespace Arkham.Model
{
    public class PlayerData
    {
        public string CurrentScenario { get; set; }
        public Dictionary<string, Investigator> AllInvestigatorsDictionary { get; set; }
        public Dictionary<string, string> CampaignsState { get; set; }
    }
}
