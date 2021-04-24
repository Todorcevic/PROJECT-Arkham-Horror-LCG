using Arkham.EventData;
using Arkham.Services;
using Zenject;

namespace Arkham.Views
{
    public class VisibilitySwitchPresenter : IInitializable
    {
        [Inject(Id = "VisibilitySwitch")] private readonly SwitchView visibilitySwitch;
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;

        private bool IsOnVisibility => playerPrefs.LoadCardsVisibility();

        /*******************************************************************/
        void IInitializable.Initialize()
        {
            visibilityEvent.AddVisibilityAction(SaveState);
            visibilitySwitch.SwitchAnimation(IsOnVisibility);
        }

        /*******************************************************************/
        private void SaveState(bool isOn) => playerPrefs.SaveCardsVisibility(isOn);
    }
}
