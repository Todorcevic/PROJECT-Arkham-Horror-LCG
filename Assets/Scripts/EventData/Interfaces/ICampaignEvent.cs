using System;

namespace Arkham.EventData
{
    public interface ICampaignEvent
    {
        event Action<string, string> CampaignStateChanged;
    }
}
