using Arkham.EventData;
using Arkham.Services;
using Arkham.Views;
using Zenject;

namespace Arkham.Presenters
{
    public class VisibilitySwitchPresenter : IInitializable
    {
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [Inject(Id = "VisivilitySwitch")] private readonly ISwitch switchView;

        /*******************************************************************/
        public void Initialize()
        {
            visibilityEvent.VisibilityChanged += Visual;
            switchView.AnimateSwitch(playerPrefs.LoadCardsVisibility());
        }

        public void Visual(bool isOn)
        {
            switchView.ClickSound();
            switchView.AnimateSwitch(isOn);
            if (switchView.SaveValue) playerPrefs.SaveCardsVisibility(isOn);
        }
    }
}
