using Arkham.Model;
using System.Collections.Generic;

namespace Arkham.Services
{
    public interface ICampaignStateFactory
    {
        List<CampaignState> Create();
    }
}
