using Arkham.Services;
using System.Collections.Generic;
using Zenject;

namespace Arkham.Application
{
    public class BackButtonController : IInitializable
    {
        [Inject(Id = "BackButton")] private readonly List<ButtonView> backButtons;
        [Inject(Id = "MainPanelsManager")] private readonly PanelsMediator panelsManager;
        [Inject(Id = "HomePanel")] private readonly PanelView homePanel;
        [Inject] private readonly DataContext dataPersistence;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            foreach (ButtonView button in backButtons)
                button.ClickAction += Clicked;
        }

        /*******************************************************************/
        private void Clicked()
        {
            dataPersistence.SaveProgress();
            panelsManager.SelectPanel(homePanel);
        }
    }
}
