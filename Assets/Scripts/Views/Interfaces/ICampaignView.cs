using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkham.Views
{
    public interface ICampaignView : IView
    {
        bool IsOpen { get; set; }
        string FirstScenarioId { get; }
        void SetImageState(Sprite icon);
    }
}
