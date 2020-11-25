using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Arkham.UI;

namespace Arkham.Controller
{
    public class PanelController
    {
        private static PanelComponent currentPanel;

        public void SelectPanel(PanelComponent panel)
        {
            if (currentPanel != null) currentPanel.Desactivate();
            panel.Activate();
            currentPanel = panel;
        }
    }
}
