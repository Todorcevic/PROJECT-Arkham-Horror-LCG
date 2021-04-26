using System;

namespace Arkham.Repositories
{
    public interface ICampaignStateChangedEvent
    {
        void Subscribe(Action<string, string> action);
    }
}
