using System;

namespace Arkham.EventData
{
    public interface ICampaignEvent
    {
        void AddAction(Action<string, string> action);
    }
}
