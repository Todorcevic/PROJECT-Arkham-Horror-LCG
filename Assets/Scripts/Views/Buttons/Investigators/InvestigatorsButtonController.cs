﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Arkham.Views
{
    public class InvestigatorsButtonController : IInitializable
    {
        [Inject(Id = "InvestigatorsButton")] private readonly IClickable investigatorsButton;
        [Inject(Id = "MidPanelsManager")] private readonly IPanelsManager panelsManager;
        [Inject(Id = "InvestigatorsPanel")] private readonly PanelView investigatorsPanel;
        [Inject(Id = "InvestigatorsPanel")] private readonly RectTransform panelToScroll;
        [Inject(Id = "MidZone")] private readonly ScrollRect scroll;

        /*******************************************************************/
        void IInitializable.Initialize() => investigatorsButton.AddAction(Clicked);

        /*******************************************************************/
        private void Clicked()
        {
            panelsManager.SelectPanel(investigatorsPanel);
            scroll.content = panelToScroll;
        }
    }
}