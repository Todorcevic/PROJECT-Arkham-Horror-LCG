using System.Collections.Generic;
using Zenject;

namespace Arkham.View
{
    public class BackButtonController : IInitializable
    {
        [Inject(Id = "BackButton")] private readonly List<ButtonView> backButtons;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (ButtonView button in backButtons)
                button.AddClickAction(Clicked);
        }

        /*******************************************************************/
        private void Clicked() => panelsManager.SelectPanel(homePanel);
    }
}
