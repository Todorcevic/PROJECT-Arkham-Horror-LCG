using Zenject;
using Arkham.Services;
using Arkham.Model;

namespace Arkham.Application
{
    public class VisibilitySwitchController : IInitializable, IVisibility
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitchView;
        [Inject] private readonly InvestigatorsCardPresenter investigatorVisibility;
        [Inject] private readonly DeckCardVisibilityPresenter cardVisibility;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;

        public bool IsOn => visibilitySwitchView.IsOn;

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
            playerPrefs.SaveCardsVisibility(IsOn);
            investigatorVisibility.RefreshInvestigatorsVisibility();
            cardVisibility.RefreshCardsVisibility();
        }
    }
}