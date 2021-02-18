using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Iterators
{
    public interface ICampaignInteractor
    {
        void InitializeCampaigns();
        void AddScenarioToPlay(string scenario);
    }
}
