using System;
using Zenject;

namespace Arkham.Application.MainMenu
{
    public class VisibilitySwitchEventHandler : IInitializable, IDisposable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly PlayerPrefService playerPrefs;
        [Inject] private readonly InvestigatorsCardPresenter investigatorCardPresenter;
        [Inject] private readonly DeckCardPresenter deckCardPresenter;

        /*******************************************************************/
        void IInitializable.Initialize() => visibilitySwitchView.ClickAction += Clicked;
        void IDisposable.Dispose() => visibilitySwitchView.ClickAction -= Clicked;

        /*******************************************************************/
        private void Clicked()
        {
            playerPrefs.SaveCardsVisibility(visibilitySwitchView.IsOn);
            investigatorCardPresenter.RefreshInvestigatorsVisibility();
            deckCardPresenter.RefreshCardsVisibility();
        }
    }
}