using Arkham.EventData;
using Arkham.Services;
using Arkham.Views;
using UnityEngine;
using Zenject;

namespace Arkham.ViewAdapters
{
    public class VisibilitySwitchPresenter : MonoBehaviour
    {
        [Inject] private readonly IVisibilityEvent visibilityEvent;
        [Inject] private readonly IPlayerPrefsAdapter playerPrefs;
        [SerializeField] private SwitchView switchView;

        /*******************************************************************/
        private void Start()
        {
            visibilityEvent.AddAction(Effect);
            switchView.AnimateSwitch(playerPrefs.LoadCardsVisibility());
        }

        /*******************************************************************/
        private void Effect(bool isOn)
        {
            switchView.ClickSound();
            switchView.AnimateSwitch(isOn);
            if (switchView.SaveValue) playerPrefs.SaveCardsVisibility(isOn);
        }
    }
}
