using System.Collections.Generic;
using Zenject;

namespace Arkham.Views
{
    public class BackButtonController : IInitializable
    {
        [Inject(Id = "BackButton")] private readonly List<IClickable> backButtons;
        [Inject(Id = "MainPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (IClickable button in backButtons)
                button.AddAction(Clicked);
        }

        /*******************************************************************/
        private void Clicked() => panelsManager.SelectPanel(homePanel);
    }
}
