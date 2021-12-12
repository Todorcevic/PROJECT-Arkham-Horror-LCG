using Zenject;
using Arkham.Services;

namespace Arkham.Application
{
    public class VisibilitySwitchController : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardPresenter cardVisibility;
        [Inject] private readonly PlayerPrefsAdapter playerPrefs;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            bool IsOnVisibility = playerPrefs.LoadCardsVisibility();
            visibilitySwitchView.SwitchAnimation(IsOnVisibility);
            visibilitySwitchView.ClickAction += Clicked;
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