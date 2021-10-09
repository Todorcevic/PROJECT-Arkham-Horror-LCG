﻿using Zenject;
using Arkham.Services;
using Arkham.Model;

namespace Arkham.Application
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            bool IsOnVisibility = playerPrefs.LoadCardsVisibility();
            visibilitySwitchView.SwitchAnimation(IsOnVisibility);
            visibilitySwitchView.AddClickAction(Clicked);
        }

        /*******************************************************************/
        public void Clicked()
        {
            playerPrefs.SaveCardsVisibility(visibilitySwitchView.IsOn);
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}