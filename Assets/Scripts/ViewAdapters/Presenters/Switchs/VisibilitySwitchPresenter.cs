using Arkham.EventData;
using Arkham.Services;
using Zenject;

namespace Arkham.Presenters
{
    public class VisibilitySwitchPresenter : IInitializable
    {
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject] private readonly ISwitchView switchView;

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            visibilityEvent.AddAction(Effect);
            switchView.SwitchAnimation(playerPrefs.LoadCardsVisibility());
        }

        /*******************************************************************/
        private void Effect(bool isOn)
        {
            switchView.ClickSound();
            switchView.SwitchAnimation(isOn);
            if (switchView.SaveValue) playerPrefs.SaveCardsVisibility(isOn);
        }
    }
}
