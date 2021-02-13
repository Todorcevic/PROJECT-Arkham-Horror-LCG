using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkham.Views
{
    public interface ICampaignState
    {
        string Id { get; }
        bool IsOpen { get; }
        void ExecuteState(ICampaignView campaignView);
    }
}
