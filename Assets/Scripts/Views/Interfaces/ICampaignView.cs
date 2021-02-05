using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkham.Views
{
    public interface ICampaignView
    {
        string Id { get; }
        bool IsOpen { get; set; }
        string FirstScenarioId { get; }
        void SetImageState(Sprite icon);
        void ClickEffect();
        void HoverOnEffect();
        void HoverOffEffect();
    }
}
